using EmployeeManagement.BL.DTOs;
using EmployeeManagement.Core.Entities;

namespace EmployeeManagement.BL.Services.Implementations;

public interface IEmployeeService
{
    Task<Employee> GetByIdAsync(int id);
    Task<ICollection<EmployeeListDto>> GetAllAsync();
    Task<Employee> CreateAsync(EmployeeCreateDto employee);
    Task<Employee> UpdateAsync(EmployeeUpdateDto employee);
    Task DeleteAsync(int id);
}
