using to_do_list.web.Models;

namespace to_do_list.web.ViewModels
{
    public class ToDoListViewModel
    {
        public List<ToDoItemModel> ToDoList { get; set; }
        public ToDoItemViewModel ToDoItem { get; set; }

    }
}