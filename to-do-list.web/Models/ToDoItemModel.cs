namespace to_do_list.web.Models
{
    public class ToDoItemModel
    {
        public int ItemId { get; set; }
        public string? Name { get; set; }
        public bool Completed { get; set; } = false;
    }
}
