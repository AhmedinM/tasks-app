using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services.Accounts;
using Core.DTOs.Users;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterUser(CreateUserDto createUserDto)
        {
            try
            {
               var user = await _accountService.RegisterUser(createUserDto);
               return Created("User is successfully created", user);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("register-admin")]
        public async Task<ActionResult<UserDto>> RegisterAdmin(CreateUserDto createUserDto)
        {
            try
            {
               var user = await _accountService.RegisterAdmin(createUserDto);
               return Created("User is successfully created", user);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(CreateUserDto createUserDto)
        {
            try
            {
                var user = await _accountService.Login(createUserDto);

                return Created("User is successfully logged in", user);
            }
            catch (System.Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [Authorize(Roles = "User")]
        [HttpPut("update-password/{userId}")]
        public async Task<ActionResult<UserDto>> UpdatePassword(int userId, UpdatePasswordDto updatePasswordDto) {
            if (userId != updatePasswordDto.Id) return BadRequest("IDs are not the same");

            try
            {
                var result = await _accountService.UpdatePassword(updatePasswordDto);

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("delete/{userId}")]
        public async Task<ActionResult<bool>> DeleteAccount(int userId, UpdateUserDto updateUserDto) {
            if (userId != updateUserDto.Id) return BadRequest("IDs are not the same");

            var result = await _accountService.DeleteUser(updateUserDto);

            return (result == false) ?
                BadRequest("Your info is incorrect") :
                NoContent();
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("delete-user/{userId}")]
        public async Task<ActionResult<bool>> AdminDeleteUser(int userId, DeleteUserDto deleteUserDto) {
            if (userId != deleteUserDto.Id) return BadRequest("IDs are not the same");

            var result = await _accountService.AdminDeleteUser(deleteUserDto);

            return NoContent();
        }
    }
}