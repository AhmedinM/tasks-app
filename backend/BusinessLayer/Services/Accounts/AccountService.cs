using AutoMapper;
using Core.DTOs.Users;
using Core.Entities;
using EFCore.Repositories.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
         private readonly UserManager<User> _userManager;
        public AccountService(UserManager<User> userManager,
            IMapper mapper, ITokenService tokenService,
            SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> CheckEmail(string email)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<UserDto> RegisterUser(CreateUserDto createUserDto)
        {
            var user = new User
            {
                UserName = createUserDto.Email,
                Email = createUserDto.Email,
            };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if(!result.Succeeded)
                throw new Exception(result.ToString());

            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if(!roleResult.Succeeded)
                throw new Exception(result.ToString());

            var token = await _tokenService.CreateToken(user);

            var res = _mapper.Map<UserDto>(user);
            res.Roles = new List<string>();
            res.Roles.Add("User");
            res.Token = token;

            return res;
        }

        public async Task<UserDto> Login(CreateUserDto createUserDto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Email == createUserDto.Email);

            if (user == null)
                throw new Exception("Email doesn't exist");

            
            var result = await _signInManager.CheckPasswordSignInAsync(user, createUserDto.Password, false);

            if (result.Succeeded)
            {
                var user2 = await _userManager.Users
                .Include(u => u.UserRoles)
                .ThenInclude(u => u.Role)
                .Select(u => new
                {
                    u.Id,
                    Email = u.Email,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                })
                .FirstOrDefaultAsync(u => u.Email == createUserDto.Email);

                var user3 = new UserDto
                {
                    Id = user2.Id,
                    Email = user2.Email,
                    Roles = user2.Roles
                };

                var token = await _tokenService.CreateToken(user);

                user3.Token = token;

                return user3;
            }
            else
            {
                throw new Exception("Password is incorrect");
            }
            
        }

        public async Task<GetUserDto> UpdatePassword(UpdatePasswordDto updatePasswordDto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == updatePasswordDto.Id);

            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, updatePasswordDto.OldPassword, updatePasswordDto.Password);

                if (result.Succeeded)
                    return _mapper.Map<GetUserDto>(await _userManager.Users.SingleOrDefaultAsync(u => u.Id == updatePasswordDto.Id));

                throw new Exception("Wrong password");
            }

            throw new Exception("Failed");
        }

        public async Task<bool> DeleteUser(UpdateUserDto updateUserDto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == updateUserDto.Id);

            if (user == null)
                return false;

            var result = await _signInManager.CheckPasswordSignInAsync(user, updateUserDto.Password, false);

            if (result.Succeeded)
            {
                await _userManager.DeleteAsync(user);

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<UserDto> RegisterAdmin(CreateUserDto createUserDto)
        {
            var user = new User
            {
                UserName = createUserDto.Email,
                Email = createUserDto.Email,
            };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if(!result.Succeeded)
                throw new Exception(result.ToString());
                
            var roleResult = await _userManager.AddToRoleAsync(user, "Admin");

            if(!roleResult.Succeeded)
                throw new Exception(result.ToString());

            var token = _tokenService.CreateToken(user);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> AdminDeleteUser(DeleteUserDto deleteUserDto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == deleteUserDto.Id);

            if (user == null)
                return false;

            await _userManager.DeleteAsync(user);

            return true;
        }
    }
}