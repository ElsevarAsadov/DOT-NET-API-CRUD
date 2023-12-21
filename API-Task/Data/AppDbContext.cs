using API_Task.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Task.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
    }
}
