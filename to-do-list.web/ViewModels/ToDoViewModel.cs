using to_do_list.web.Models;

namespace to_do_list.web.ViewModels
{
    public class ToDoViewModel
    {
        public List<ToDoItemModel> ToDoList { get; set; }
        public string Name { get; set; }
    }
}
