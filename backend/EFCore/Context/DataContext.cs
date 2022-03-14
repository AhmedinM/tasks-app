
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Core.Entities.Task;

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

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt).HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<List>()
                .Property(l => l.Name).IsRequired();

            modelBuilder.Entity<List>()
                .Property(l => l.CreatedAt).HasDefaultValue(DateTime.Now);
            
            modelBuilder.Entity<Task>()
                .Property(t => t.Text).IsRequired();

            modelBuilder.Entity<Task>()
                .Property(t => t.CreatedAt).HasDefaultValue(DateTime.Now);
            
            modelBuilder.Entity<Task>()
                .Property(t => t.Finished).HasDefaultValue(false);
        }
    }
}