using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Users;
using Core.Entities;
using EFCore.Repositories.Users;

namespace BusinessLayer.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<GetUserDto>> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            return _mapper.Map<List<GetUserDto>>(users);
        }
    }
}