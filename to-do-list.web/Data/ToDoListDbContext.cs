using Microsoft.EntityFrameworkCore;
using to_do_list.web.Models;

namespace to_do_list.web.Data
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext (DbContextOptions<ToDoListDbContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoItemModel> ToDoItemModel { get; set; } = default!;
    }
}
