using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo>Todos { get; set; }
    }
}
