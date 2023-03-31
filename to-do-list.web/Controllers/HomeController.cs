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

            return View("Index", new ToDoViewModel() { ToDoList = items });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ToDoViewModel createModel)
        {
            if (createModel.Name == null || createModel.Name == string.Empty)
            {
                return NotFound();
            }

            _context.ToDoItemModel.Add(new ToDoItemModel() { ItemId = new int(), Name = createModel.Name });
            _context.SaveChanges();

            var toDoList = new ToDoViewModel() { ToDoList = _context.ToDoItemModel.ToList() };

            return View("Index", toDoList);
        }

        //Add delete option for each to-do list item on interface that links to this action.
        public async Task<IActionResult> Delete(int? itemId)
        {
            if (itemId == null)
            {
                return NotFound();
            }

            _context.ToDoItemModel.Remove(new ToDoItemModel() { ItemId = (int)itemId});
            await _context.SaveChangesAsync();

            var toDoList = new ToDoViewModel() { ToDoList = _context.ToDoItemModel.ToList() };

            return View("Index", toDoList);
        }
    }
}