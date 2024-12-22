using EmployeeManagement.BL.DTOs;
using EmployeeManagement.BL.Exceptions;
using EmployeeManagement.BL.Services.Implementations;
using EmployeeManagement.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet("{id}", Name = "GetDepartmentById")]
    public async Task<ActionResult<Department>> GetById(int id)
    {
        try
        {
            return Ok(await _departmentService.GetByIdAsync(id));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status204NoContent, new { message = ex.Message });
        }
    }

    [HttpGet(Name = "GetAllDepartments")]
    public async Task<ActionResult<ICollection<DepartmentListDto>>> GetAll()
    {
        return Ok(await _departmentService.GetAllAsync());
    }

    [HttpPost("Create", Name = "CreateDepartment")]
    public async Task<ActionResult<Department>> CreateDepartment(DepartmentCreateDto departmentDto)
    {
        return StatusCode(StatusCodes.Status201Created, await _departmentService.CreateAsync(departmentDto));
    }

    [HttpPut("Update", Name = "UpdateDepartment")]
    public async Task<ActionResult<Department>> UpdateDepartment(DepartmentUpdateDto departmentDto)
    {
        try
        {
            return Ok(await _departmentService.UpdateAsync(departmentDto));
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status204NoContent, new { message = ex.Message });
        }
    }

    [HttpDelete("Delete", Name = "DeleteDepartment")]
    public async Task<ActionResult> DeleteDepartment(int id)
    {
        try
        {
            await _departmentService.DeleteAsync(id);
            return Ok();
        }
        catch (EntityNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status204NoContent, new { message = ex.Message });
        }
    }
}
