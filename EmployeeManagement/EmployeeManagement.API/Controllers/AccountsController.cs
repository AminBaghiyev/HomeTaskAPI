using EmployeeManagement.BL.DTOs;
using EmployeeManagement.BL.Exceptions;
using EmployeeManagement.BL.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
	readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("AllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            return Ok(await _accountService.GetAllUsers());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
    }

    [HttpGet("User")]
    public async Task<IActionResult> GetUser(string email)
    {
        try
        {
            return Ok(await _accountService.GetOneUser(email));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
        }
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(CreateUserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

		try
		{
            await _accountService.RegisterAsync(dto);
            return StatusCode(StatusCodes.Status201Created);
		}
		catch (UserExistsException ex)
		{
            return StatusCode(StatusCodes.Status409Conflict, new { message = ex.Message });
        }
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
		}
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return StatusCode(StatusCodes.Status200OK, await _accountService.LoginAsync(dto));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (UserLoginCouldNotBeVerifiedException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpGet("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        try
        {
            await _accountService.ConfirmEmailAsync(userId, token);
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (UserEmailCouldNotBeVerifiedException ex)
        {
            return StatusCode(StatusCodes.Status422UnprocessableEntity, new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }

    [HttpPatch("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _accountService.ChangePasswordAsync(dto);
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
        }
    }
}
