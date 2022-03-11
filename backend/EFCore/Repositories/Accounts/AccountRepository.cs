using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Users;
using Core.Entities;
using EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repositories.Users
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;
        public AccountRepository(DataContext context)
        {
            _context = context;
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public Task<GetUserDto> Login(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterUser(User user)
        {
             await _context.Users.AddAsync(user);
             await _context.SaveChangesAsync();

             return await GetUserByEmail(user.Email);
        }
    }
}