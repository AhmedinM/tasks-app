using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Users;
using Core.Entities;
using EFCore.Repositories.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<User> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<GetUserDto> GetUser(int userId)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
            
            return _mapper.Map<GetUserDto>(user);
        }

        public async Task<GetUserDto> GetUserByEmail(string email)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Email == email);
            
            return _mapper.Map<GetUserDto>(user);
        }

        public async Task<List<GetUserDto>> GetUsers(int userId)
        {
            var users = await _userManager.Users
                .Include(u => u.UserRoles)
                .ThenInclude(u => u.Role)
                .OrderByDescending(u => u.CreatedAt)
                .Select(u => new
                {
                    u.Id,
                    Email = u.Email,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList(),
                    CreatedAt = u.CreatedAt
                })
                .ToListAsync();

            var newUsers = new List<GetUserDto>();

            foreach (var user in users)
            {
                var user2 = new GetUserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Roles = user.Roles,
                    CreatedAt = user.CreatedAt
                };
                newUsers.Add(user2);
            }
            
            // return _mapper.Map<List<GetUserDto>>(users);
            return newUsers;

        }
    }
}