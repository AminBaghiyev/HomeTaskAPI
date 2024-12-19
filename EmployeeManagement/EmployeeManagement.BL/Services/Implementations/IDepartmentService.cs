using EmployeeManagement.BL.DTOs;
using EmployeeManagement.Core.Entities;

namespace EmployeeManagement.BL.Services.Implementations;

public interface IDepartmentService
{
    Task<Department> GetByIdAsync(int id);
    Task<ICollection<DepartmentListDto>> GetAllAsync();
    Task<Department> CreateAsync(DepartmentCreateDto departmentDto);
    Task<Department> UpdateAsync(DepartmentUpdateDto departmentDto);
    Task DeleteAsync(int id);
}
