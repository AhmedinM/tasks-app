using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Seeders
{
    public class Seed
    {
        public static async System.Threading.Tasks.Task SeedUsers(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (await userManager.Users.AnyAsync())
                return;

            var roles = new List<Role>
            {
                new Role
                    { Name = "User" },
                new Role
                    { Name = "Admin" },
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            var user = new User
            {
                UserName = "user@test.com",
                Email = "user@test.com",
                PasswordHash = "kjfhkjdsdfskghd"
            };

            var admin = new User
            {
                UserName = "admin@test.com",
                Email = "admin@test.com",
                PasswordHash = "kjfhkjdsdfskghd",
            };

            await userManager.CreateAsync(user, "pass");
            await userManager.AddToRoleAsync(user, "User");
            await userManager.CreateAsync(admin, "pass");
            await userManager.AddToRoleAsync(admin, "Admin");
            // await userManager.AddToRolesAsync(admin, new [] {"Admin", "User"});
        }
    }
}