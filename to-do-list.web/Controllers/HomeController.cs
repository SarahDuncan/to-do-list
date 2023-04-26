using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using to_do_list.web.Data;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _context.ToDoItemModel.ToListAsync();

            return View("Index", new ToDoListViewModel() { ToDoList = items });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int? id, bool completed)
        {
            var toDoList = await _context.ToDoItemModel.ToListAsync();

            if (id != null)
            {
                var toDoItem = toDoList.Find(x => x.Id == id);

                if (toDoItem != null)
                {
                    toDoItem.Completed = completed;
                    _context.ToDoItemModel.Update(toDoItem);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}