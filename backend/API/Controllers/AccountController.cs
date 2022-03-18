using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services.Accounts;
using Core.DTOs.Users;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser(CreateUserDto createUserDto)
        {
            var user = await _accountService.RegisterUser(createUserDto);

            return (user.Email == null) ?
                BadRequest("Email already exists") :
                Created("User is successfully created", user);
        }

        [HttpPost("register-admin")]
        public async Task<ActionResult<UserDto>> RegisterAdmin(CreateUserDto createUserDto)
        {
            var user = await _accountService.RegisterAdmin(createUserDto);

            return (user.Email == null) ?
                BadRequest("Email already exists") :
                Created("User is successfully created", user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(CreateUserDto createUserDto)
        {
            var user = await _accountService.Login(createUserDto);
            
            return (user.Email == null) ?
                Unauthorized("Your info is incorrect") :
                Created("User is successfully logged in", user);
        }

        [HttpPut("update-password/{userId}")]
        public async Task<ActionResult<UserDto>> UpdatePassword(int userId, UpdateUserDto updateUserDto) {
            if (userId != updateUserDto.Id) return BadRequest("IDs are not the same");

            var result = await _accountService.UpdatePassword(updateUserDto);

            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [HttpDelete("delete/{userId}")]
        public async Task<ActionResult<bool>> DeleteAccount(int userId, UpdateUserDto updateUserDto) {
            if (userId != updateUserDto.Id) return BadRequest("IDs are not the same");

            var result = await _accountService.DeleteUser(updateUserDto);

            return (result == false) ?
                BadRequest("Your info is incorrect") :
                NoContent();
        }

        [HttpDelete("delete-user/{userId}")]
        public async Task<ActionResult<bool>> AdminDeleteUser(int userId, DeleteUserDto deleteUserDto) {
            if (userId != deleteUserDto.Id) return BadRequest("IDs are not the same");

            var result = await _accountService.AdminDeleteUser(deleteUserDto);

            return NoContent();
        }
    }
}