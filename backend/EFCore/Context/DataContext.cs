
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Core.Entities.Task;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<List>  Lists { get; set; }
        public DbSet<Task> Tasks { get; set; }
      
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Task>()
                .Property(t => t.Finished).HasDefaultValue(false);
        }
    }
}