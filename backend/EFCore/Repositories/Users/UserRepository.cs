using Core.Entities;
using EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(int userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
            
            if (user == null)
                throw new NullReferenceException(null);
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);

            if (user == null)
                throw new NullReferenceException(null);
            return user;
        }

        public async Task<List<User>> GetUsers(int userId)
        {
            return await _context.Users.Where(u => u.Id != userId).OrderByDescending(u => u.CreatedAt).ToListAsync();
        }
    }
}