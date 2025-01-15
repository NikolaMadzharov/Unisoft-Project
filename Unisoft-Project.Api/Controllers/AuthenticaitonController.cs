using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unisoft_Project.Core.Contracts;
using Unisoft_Project.Core.Models;

namespace Unisoft_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticaitonController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticaitonController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserDTO loginUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var token = await _userService.LoginUserAsync(loginUserDTO);
                return Ok(new { token });
            }
            catch (ArgumentException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserDTO registerUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var token = await _userService.RegisterUserAsync(registerUserDTO);
                return Ok(new { Token = token });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetUserDetailsAsync(string userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(user);
        }


        [HttpPut("{userId}")]
        [Authorize]
        public async Task<IActionResult> UpdateUserProfileAsync(string userId, [FromBody] EditUserDTO editUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = await _userService.UpdateUserProfileAsync(userId, editUserDTO);

                if (user == null)
                {
                    return NotFound(new { message = "User not found" });
                }

                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
 }
