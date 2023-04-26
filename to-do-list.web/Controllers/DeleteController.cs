using Microsoft.AspNetCore.Mvc;
using to_do_list.web.Data;

namespace to_do_list.web.Controllers
{
    public class DeleteController : Controller
    {
        private readonly ToDoListDbContext _dbContext;

        public DeleteController(ToDoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> DeleteItem(int itemId)
        {
            if (itemId == 0)
            {
                return NotFound();
            }

            var todoItem = _dbContext.ToDoItemModel.FirstOrDefault(t => t.Id == itemId);
            _dbContext.ToDoItemModel.Remove(todoItem);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteList()
        {
            var todoList = _dbContext.ToDoItemModel.ToList();
            _dbContext.RemoveRange(todoList);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
