using Book.BL.DTOs.BookDtos;
using Book.BL.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Entities = Book.Core.Entities;

namespace Book.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService book)
    {
        _bookService = book;
    }
    [HttpGet]
   
    public async Task<ICollection<Entities.Book>> GetAll()
    {
        return await _bookService.GetAllAsync();
    }
    [HttpPost]
    public async Task<IActionResult> Create(BookCreateDto createDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        };
        return StatusCode(StatusCodes.Status201Created, await _bookService.CreateAsync(createDto));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
             return StatusCode(StatusCodes.Status200OK, await _bookService.GetByIdAsync(id));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status404NotFound, e.Message);
        }
    }
    [HttpDelete("{id}")]
    
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _bookService.SoftDeleteAsync(id));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }

    [HttpPut("updatebook/{id}" )]
    public async Task<IActionResult> Update(int id, BookCreateDto bookUpdateDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _bookService.UpdateAsync(id, bookUpdateDto));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }
    [HttpPatch("updatebook/{id}")]
    public async Task<IActionResult> Edit(int id, BookEditDto bookEditDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }
        try
        {
            return StatusCode(StatusCodes.Status200OK, await _bookService.EditAsync(id, bookEditDto));
        }
        catch (Exception e)
        {

            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
    }
}
