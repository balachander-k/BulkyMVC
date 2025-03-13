using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Category> Catgories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Web Development", DisplayOrder = 1 },
                new Category { ID = 2, Name = "Mobile Development", DisplayOrder = 2 },
                new Category { ID = 3, Name = "Full Stack Development", DisplayOrder = 3 }
                );
        }
            
        
    }
}
