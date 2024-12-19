using EmployeeManagement.BL.DTOs;
using EmployeeManagement.BL.Exceptions;
using EmployeeManagement.BL.Services.Implementations;
using EmployeeManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{id}", Name = "GetEmployeeById")]
    public async Task<ActionResult<Employee>> GetById(int id)
    {
        try
        {
            return Ok(await _employeeService.GetByIdAsync(id));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status204NoContent, new { message = ex.Message });
        }
    }

    [HttpGet(Name = "GetAllEmployees")]
    public async Task<ActionResult<ICollection<EmployeeListDto>>> GetAll()
    {
        return Ok(await _employeeService.GetAllAsync());
    }

    [HttpPost("Create", Name = "CreateEmployee")]
    public async Task<ActionResult<Employee>> CreateEmployee(EmployeeCreateDto employeeDto)
    {
        try
        {
            return StatusCode(StatusCodes.Status201Created, await _employeeService.CreateAsync(employeeDto));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status204NoContent, new { message = ex.Message });
        }
    }

    [HttpPost("Update", Name = "UpdateEmployee")]
    public async Task<ActionResult<Employee>> UpdateEmployee(EmployeeUpdateDto employeeDto)
    {
        try
        {
            return Ok(await _employeeService.UpdateAsync(employeeDto));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status204NoContent, new { message = ex.Message });
        }
    }

    [HttpDelete("Delete", Name = "DeleteEmployee")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        try
        {
            await _employeeService.DeleteAsync(id);
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status204NoContent, new { message = ex.Message });
        }
    }
}
