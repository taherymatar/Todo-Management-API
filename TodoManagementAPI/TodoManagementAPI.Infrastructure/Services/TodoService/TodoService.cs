using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoManagementAPI.Core.Dtos;
using TodoManagementAPI.Core.Dtos.Helpers;
using TodoManagementAPI.Core.Enums;
using TodoManagementAPI.Core.ViewModels;
using TodoManagementAPI.Data;
using TodoManagementAPI.Data.Models;

namespace TodoManagementAPI.Infrastructure.Services.TodoService
{
    public class TodoService : ITodoService
    {
        private readonly TodoManagementDbContext _context;
        private readonly IMapper _mapper;

        public TodoService(TodoManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TodoViewModel>> GetAll(Query query)
        {
            var queryString = _context.Todos.AsQueryable();

            if (query.status.HasValue)
            {
                queryString = queryString.Where(x => x.Status == query.status.Value);
            }

            var dataList = await queryString.ToListAsync();
            var todos = _mapper.Map<List<TodoViewModel>>(dataList);
            return todos;
        }
        public async Task<T> GetById<T>(Guid id)
        {
            var todo = await _context.Todos.SingleOrDefaultAsync(x => x.Id == id);

            if (todo == null)
            {
                throw new Exception();
            }

            var dto = _mapper.Map<T>(todo);
            return dto;
        }
        
        public async Task<Guid> Create(CreateTodoDto dto)
        {
            var todo = _mapper.Map<Todo>(dto);
            todo.Id = Guid.NewGuid(); // Note: ID generation may be moved to the Todo class constructor 

            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();

            return todo.Id;
        }
        public async Task<Guid> Update(UpdateTodoDto dto)
        {
            var todo = await _context.Todos.SingleOrDefaultAsync(x => x.Id == dto.Id);
            if (todo == null)
            {
                throw new Exception();
            }

            var updatedTodo = _mapper.Map(dto, todo);
            updatedTodo.LastModifiedDate = DateTime.Now;

            _context.Update(updatedTodo);
            await _context.SaveChangesAsync();

            return updatedTodo.Id;
        }
        // Currently using hard delete.
        // To switch to soft delete later, we can:
        // - Add an IsDeleted field
        // - Replace Remove with an update to set IsDeleted = true
        // - Exclude IsDeleted records in queries
        public async Task<Guid> Delete(Guid id)
        {
            var todo = await _context.Todos.SingleOrDefaultAsync(x => x.Id == id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }

            return todo.Id;
        }

        public async Task<Guid> MarkAsComplete(Guid id)
        {
            var todo = await _context.Todos.SingleOrDefaultAsync(x => x.Id == id);
            if (todo == null)
            {
                throw new Exception();
            }

            todo.Status = TodoStatus.Completed;
            todo.LastModifiedDate = DateTime.Now;

            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();

            return todo.Id;
        }
    }
}
