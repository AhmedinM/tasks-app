using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Users;
using Core.Entities;
using EFCore.Context;
using EFCore.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repositories.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        public AccountRepository(DataContext context, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async System.Threading.Tasks.Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public Task<User> GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        // public Task<GetUserDto> Login(CreateUserDto createUserDto)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<User> RegisterUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            //  return await GetUserByEmail(user.Email);
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return await _userRepository.GetUser(user.Id);
        }
    }
}