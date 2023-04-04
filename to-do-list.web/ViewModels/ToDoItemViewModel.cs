namespace to_do_list.web.ViewModels
{
    public class ToDoItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; } = false;
    }
}
