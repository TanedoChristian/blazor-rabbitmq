using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlazorApp.Entities.User> Users { get; set; }
    }
}
