using Core.Entities;
using EFCore.Context;
using EFCore.Repositories.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repositories.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        public AccountRepository(DataContext context, IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _context = context;
            _userManager = userManager;
        }

        public async System.Threading.Tasks.Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _userManager.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> RegisterUser(User user, string password)
        {
            await _context.Users.AddAsync(user);
            var u = await _userManager.CreateAsync(user, password);
            await _context.SaveChangesAsync();

            var user2 = await GetUserByEmail(user.Email);

            if (user2 == null)
                throw new NullReferenceException(null);
            return user2;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return await _userRepository.GetUser(user.Id);
        }
    }
}