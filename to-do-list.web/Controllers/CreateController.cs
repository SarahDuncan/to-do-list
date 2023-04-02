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
            var toDoList = new ToDoViewModel() { ToDoList = items };

            return View("Create", toDoList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoViewModel createModel)
        {
            if (createModel.Name == null || createModel.Name == string.Empty)
            {
                return NotFound();
            }

            await _dbContext.ToDoItemModel.AddAsync(new ToDoItemModel() { Id = new int(), Name = createModel.Name });
            await _dbContext.SaveChangesAsync();

            var toDoList = new ToDoViewModel() { ToDoList = _dbContext.ToDoItemModel.ToList() };

            return RedirectToAction("Index", "Home");
        }
    }
}
