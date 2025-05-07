using TodoManagementAPI.Core.Dtos;
using TodoManagementAPI.Core.Dtos.Helpers;
using TodoManagementAPI.Core.ViewModels;

namespace TodoManagementAPI.Infrastructure.Services.TodoService
{
    public interface ITodoService
    {
        Task<List<TodoViewModel>> GetAll(Query query);
        Task<T> GetById<T>(Guid id);
        Task<Guid> Create(CreateTodoDto dto);
        Task<Guid> Update(UpdateTodoDto dto);
        Task<Guid> Delete(Guid id);
        Task<Guid> MarkAsComplete(Guid id);
    }
}
