using Microsoft.AspNetCore.Mvc;
using TodoManagementAPI.Core.Dtos;
using TodoManagementAPI.Core.Dtos.Helpers;
using TodoManagementAPI.Core.Enums;
using TodoManagementAPI.Core.ViewModels;
using TodoManagementAPI.Infrastructure.Services.TodoService;

namespace TodoManagementAPI.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult> Index([FromQuery] Query query)
        {
            try
            {
                var todos = await _todoService.GetAll(query);
                return View(todos);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> TodoDetails(Guid id)
        {
            try
            {
                var todo = await _todoService.GetById<TodoViewModel>(id);
                return View(todo); 
            }
            catch (Exception)
            {
                return NotFound(); 
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var todo = await _todoService.Create(dto);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            try
            {
                var todo = await _todoService.GetById<UpdateTodoDto>(id);
                return View(todo);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateTodoDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedId = await _todoService.Update(dto);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return NotFound();
                }
            }

            return View(dto);
        }
       
        // This action to confirm delete
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _todoService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsComplete(Guid id)
        {
            try
            {
                await _todoService.MarkAsComplete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
