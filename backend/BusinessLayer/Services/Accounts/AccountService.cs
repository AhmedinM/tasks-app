using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Users;
using Core.Entities;
using EFCore.Repositories.Users;

namespace BusinessLayer.Services.Users
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        private async Task<bool> CheckEmail(string email)
        {
            var user = await _accountRepository.GetUserByEmail(email);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            // return false;
        }

        public async Task<User> RegisterUser(CreateUserDto createUserDto)
        {
            var check = await CheckEmail(createUserDto.Email);
            if (!check)
            {
                using var hmac = new HMACSHA512();

                var user = new User
                {
                    Email = createUserDto.Email,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(createUserDto.Password)),
                    PasswordSalt = hmac.Key,
                    Role = "User"
                };

                // var result = _accountRepository.RegisterUser(user);

                // return _mapper.Map<GetUserDto>(result);

                return await _accountRepository.RegisterUser(user);
            }
            else
            {
                var user = new User{};
                return user;
            }
            
            // throw new NotImplementedException();
            // var user = _mapper.Map<User>(createUserDto);
            // return await _accountRepository.RegisterUser(user);
        }

        Task<bool> IAccountService.CheckEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Login(CreateUserDto createUserDto)
        {
            var user = await _accountRepository.GetUserByEmail(createUserDto.Email);

            if (user != null)
            {
                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(createUserDto.Password));

                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i]) return null;
                }

                return user;
            } else {
                return null;
            }

            // return user;
        }
    }
}