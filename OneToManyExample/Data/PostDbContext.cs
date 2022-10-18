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

            modelBuilder.Entity<PostTag>().HasKey(x => new { x.PostId, x.TagId });


            modelBuilder.Entity<Tag>().HasData(new Tag { Id = 1, Name = "Sport" }, new Tag { Id = 2, Name = "Angular" });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

    }
}
