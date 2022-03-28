using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs.Users;
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
            // return _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            return await _userManager.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        // public Task<GetUserDto> Login(CreateUserDto createUserDto)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<User> RegisterUser(User user, string password)
        {
            // await _context.Users.AddAsync(createUserDto);
            // var u = await _userManager.CreateAsync(user, password);
            // await _context.SaveChangesAsync();

            //  return await GetUserByEmail(user.Email);

            return null;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return await _userRepository.GetUser(user.Id);
        }
    }
}