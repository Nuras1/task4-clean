using Microsoft.EntityFrameworkCore;
using task4.Models;

namespace task4.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();

            user.HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
