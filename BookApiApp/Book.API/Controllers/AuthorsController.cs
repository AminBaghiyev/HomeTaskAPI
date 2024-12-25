using Book.BL.DTOs.AuthorDtos;
using Book.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Book.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }
    
    [HttpPost("Add")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(AuthorCreateDto createDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        };
        return StatusCode(StatusCodes.Status200OK, await _authorService.CreateAsync(createDto));
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllAuthors()
    {
        return Ok(await _authorService.GetAllAsync());
    }
}
