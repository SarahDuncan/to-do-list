using Microsoft.AspNetCore.Mvc;
using to_do_list.web.Data;
using to_do_list.web.Models;
using to_do_list.web.ViewModels;

namespace to_do_list.web.Controllers
{
    public class EditController : Controller
    {
        private readonly ToDoListDbContext _context;

        public EditController(ToDoListDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int itemId)
        {
            var item = _context.ToDoItemModel.FindAsync(itemId);

            var model = new ToDoListViewModel()
            {
                ToDoItem = new ToDoItemViewModel
                {
                    Id = item.Result.Id,
                    Name = item.Result.Name,
                    Completed = item.Result.Completed
                }
            };

            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(ToDoListViewModel editModel)
        {

            if (editModel.ToDoItem.Name == null || editModel.ToDoItem.Name == string.Empty)
            {
                return NotFound();
            }

            var model = new ToDoItemModel { Id = editModel.ToDoItem.Id, Name = editModel.ToDoItem.Name, Completed = editModel.ToDoItem.Completed };

            _context.ToDoItemModel.Update(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
