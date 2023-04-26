using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using to_do_list.web.Data;
using to_do_list.web.Models;
using to_do_list.web.ViewModels;

namespace to_do_list.web.Controllers
{
    public class CreateController : Controller
    {
        private readonly ToDoListDbContext _dbContext;

        public CreateController(ToDoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Create()
        {
            var items = await _dbContext.ToDoItemModel.ToListAsync();
            var toDoList = new ToDoListViewModel() { ToDoList = items };

            return View("Create", toDoList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoListViewModel createModel)
        {
            if (createModel.ToDoItem.Name == null || createModel.ToDoItem.Name == string.Empty)
            {
                return NotFound();
            }

            await _dbContext.ToDoItemModel.AddAsync(new ToDoItemModel() { Id = new int(), Name = createModel.ToDoItem.Name, Completed = false });
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}