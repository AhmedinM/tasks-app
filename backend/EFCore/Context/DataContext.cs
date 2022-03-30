
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = Core.Entities.Task;

namespace EFCore.Context
{
    public class DataContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<List>  Lists { get; set; }
        public DbSet<Task> Tasks { get; set; }
      
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

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