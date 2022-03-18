using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Users;
using Core.Entities;
using EFCore.Repositories.Accounts;
using EFCore.Repositories.Users;

namespace BusinessLayer.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        public AccountService(IAccountRepository accountRepository, IMapper mapper, ITokenService tokenService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }

        public async Task<bool> CheckEmail(string email)
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

        public async Task<UserDto> RegisterUser(CreateUserDto createUserDto)
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

                var regUser = await _accountRepository.RegisterUser(user);

                var token = _tokenService.CreateToken(regUser);

                var result = _mapper.Map<UserDto>(regUser);
                result.Token = token;

                return result;

                // return await _accountRepository.RegisterUser(user);
            }
            else
            {
                return new UserDto{};
            }
            
            // throw new NotImplementedException();
            // var user = _mapper.Map<User>(createUserDto);
            // return await _accountRepository.RegisterUser(user);
        }

        public async Task<UserDto> Login(CreateUserDto createUserDto)
        {
            var user = await _accountRepository.GetUserByEmail(createUserDto.Email);

            if (user != null)
            {
                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(createUserDto.Password));

                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i])
                    {
                        return new UserDto{};
                    }
                }

                var token = _tokenService.CreateToken(user);

                var result = _mapper.Map<UserDto>(user);
                result.Token = token;

                return result;

                // return user;
            }
            else
            {
                return new UserDto{};
            }
        }

        public async Task<GetUserDto> UpdatePassword(UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetUser(updateUserDto.Id);

            using var hmac = new HMACSHA512();

            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(updateUserDto.Password));
            var passwordSalt = hmac.Key;

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return _mapper.Map<GetUserDto>(await _accountRepository.UpdateUser(user));

            // return result;
        }

        public async Task<bool> DeleteUser(UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetUser(updateUserDto.Id);

            if (user != null)
            {
                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(updateUserDto.Password));

                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i])
                    {
                        return false;
                    }
                }

                await _accountRepository.DeleteUser(user);

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<UserDto> RegisterAdmin(CreateUserDto createUserDto)
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
                    Role = "Admin"
                };

                var regUser = await _accountRepository.RegisterUser(user);

                var token = _tokenService.CreateToken(regUser);

                var result = _mapper.Map<UserDto>(regUser);
                result.Token = token;

                return result;
            }
            else
            {
                return new UserDto{};
            }
        }
    }
}