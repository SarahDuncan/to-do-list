using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using to_do_list.web.Models;
using to_do_list.web.ViewModels;

namespace to_do_list.web.Controllers
{
    public class HomeController : Controller
    {
        private static List<ToDoItemModel> toDoList = new List<ToDoItemModel>() { new ToDoItemModel() { ItemId = new Guid(), Name = "one item" }, new ToDoItemModel() { ItemId = new Guid(), Name = "two items" } };

        public IActionResult Index()
        {
            var model = new ToDoViewModel() { ToDoList = toDoList };
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Index(ToDoItemModel createModel)
        {
            toDoList.Add(new ToDoItemModel() { ItemId = new Guid(), Name = createModel.Name });
            var model = new ToDoViewModel()
            {
                ToDoList = toDoList
            };
            return View("Index", model);

        }
    }
}