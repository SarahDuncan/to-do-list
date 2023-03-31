using to_do_list.web.Models;

namespace to_do_list.web.ViewModels
{
    public class ToDoViewModel
    {
        public List<ToDoItemModel> ToDoList { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; } = false;
    }
}
