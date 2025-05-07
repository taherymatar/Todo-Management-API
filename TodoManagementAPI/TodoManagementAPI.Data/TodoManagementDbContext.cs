using Microsoft.EntityFrameworkCore;
using TodoManagementAPI.Data.Models;

namespace TodoManagementAPI.Data
{
    public class TodoManagementDbContext : DbContext
    {
        public TodoManagementDbContext(DbContextOptions<TodoManagementDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
