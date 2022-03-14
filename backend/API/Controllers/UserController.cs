using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services.Users;
using Core.DTOs.Users;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<GetUserDto>>> GetUsers()
        {
            var result = await _userService.GetUsers();
            
            return (result == null) ?
                NotFound() :
                Ok(result);
        }

        [Authorize]
        [HttpGet("one/{userId}")]
        public async Task<ActionResult<GetUserDto>> GetUser(int userId)
        {
            var result = await _userService.GetUser(userId);
            
            return (result == null) ?
                NotFound() :
                Ok(result);
        }
    }
}