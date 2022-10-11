using Microsoft.EntityFrameworkCore;
using OneToManyExample.Models;

namespace OneToManyExample.Data
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sport" },
                new Category { Id = 2, Name = "IT" }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
