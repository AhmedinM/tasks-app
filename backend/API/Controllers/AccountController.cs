using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services.Users;
using Core.DTOs.Users;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        // private readonly ITokenService _tokenService;
        public AccountController(IAccountService accountService)
        {
            // _tokenService = tokenService;
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> RegisterUser(CreateUserDto createUserDto)
        {
            var user = await _accountService.RegisterUser(createUserDto);

            return (user == null) ?
                BadRequest("Email already exists") :
                Created("User is successfully created", user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(CreateUserDto createUserDto)
        {
            var user = await _accountService.Login(createUserDto);
            // var token = _tokenService.CreateToken(user);

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                // Token = token
            };
        }
    }
}