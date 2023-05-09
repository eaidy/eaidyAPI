using System;
using eaidyAPI.Business.Abstract;
using eaidyAPI.Entities;
using eaidyAPI.Entities.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            CUFeedback createdUserFeedback = await _userService.CreateUser(user);
            if (createdUserFeedback.feedback.isValid)
            {
                return CreatedAtAction(nameof(CreateUser), new { id = createdUserFeedback.user.id }, createdUserFeedback); // 201 code
            } else
            {
                return Conflict(new
                {
                    error = "A user with similar credential/credentials already exists.",
                    feedback = createdUserFeedback
                });
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> LoginHandler([FromBody] LoginHandlerArguments loginInfo)
        {
            var userBuffer = await _userService.LoginHandler(loginInfo.username, loginInfo.password);
            if (userBuffer != null)
            {
                return Ok(userBuffer);
            }
            else
            {
                return NotFound("No user found!");
            }
        }

    }
}

