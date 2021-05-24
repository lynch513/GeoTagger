using GeoTagger.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoTagger.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Tag> Tags => Set<Tag>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tag>().HasIndex(u => u.Name).IsUnique();
        }
    }
}
