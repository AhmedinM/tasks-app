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
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetUserDto>>> GetUsers()
        {
            var result = await _userService.GetUsers();
            if (result == null) {
                return NotFound();
            } else {
                return Ok(result);
            }
        }
    }
}