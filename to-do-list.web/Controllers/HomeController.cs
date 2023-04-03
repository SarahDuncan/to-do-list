using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using to_do_list.web.Data;
using to_do_list.web.Models;
using to_do_list.web.ViewModels;

namespace to_do_list.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ToDoListDbContext _context;

        public HomeController(ToDoListDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.ToDoItemModel.ToListAsync();

            return View("Index", new ToDoListViewModel() { ToDoList = items });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ToDoListViewModel createModel)
        {
            if (createModel.ToDoItem.Name == null || createModel.ToDoItem.Name == string.Empty)
            {
                return NotFound();
            }

            _context.ToDoItemModel.Add(new ToDoItemModel() { Id = new int(), Name = createModel.ToDoItem.Name, Completed = createModel.ToDoItem.Completed });
            _context.SaveChanges();

            var toDoList = new ToDoListViewModel() { ToDoList = _context.ToDoItemModel.ToList() };

            return View("Index", toDoList);
        }
    }
}