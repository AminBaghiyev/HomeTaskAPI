using Book.BL.DTOs.AppUserDtos;
using Book.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthsController(IAuthService authService)
        {
                _authService = authService;
        }

        [HttpPost("register")]
        public async  Task<IActionResult> Register(AppUserCreateDto appUserCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _authService.RegisterAsync(appUserCreateDto));  
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _authService.LoginAsync(appUserLoginDto));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
