using DemoSite.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoSite.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
