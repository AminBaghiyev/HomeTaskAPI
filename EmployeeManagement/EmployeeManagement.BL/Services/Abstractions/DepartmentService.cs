using EmployeeManagement.BL.DTOs;
using EmployeeManagement.BL.Exceptions;
using EmployeeManagement.BL.Services.Implementations;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.DAL.Repositories.Abstractions;

namespace EmployeeManagement.BL.Services.Abstractions;

public class DepartmentService : IDepartmentService
{
    private readonly IRepository<Department> _departmentRepository;
    private readonly IRepository<Employee> _employeeRepository;

    public DepartmentService(IRepository<Department> departmentRepository, IRepository<Employee> employeeRepository)
    {
        _departmentRepository = departmentRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        Department? department =
            await _departmentRepository.GetByIdAsync(id) ?? 
            throw new EntityNotFoundException();

        ICollection<Employee> employees = await _employeeRepository.GetAllAsync();
        foreach (Employee employee in employees)
        {
            if (employee.DepartmentId == id) department.Employees.Add(employee);
        }

        return department;
    }

    public async Task<ICollection<DepartmentListDto>> GetAllAsync()
    {
        ICollection<Department> departments = await _departmentRepository.GetAllAsync();
        ICollection<DepartmentListDto> departmentListDtos = [];

        foreach (Department department in departments)
        {
            departmentListDtos.Add(new DepartmentListDto
            {
                Id = department.Id,
                Title = department.Title,
                IsDeleted = department.IsDeleted
            });
        }

        return departmentListDtos;
    }

    public async Task<Department> CreateAsync(DepartmentCreateDto departmentDto)
    {
        Department department = new()
        {
            Title = departmentDto.Title,
            IsDeleted = departmentDto.IsDeleted,
            CreatedAt = DateTime.UtcNow.AddHours(4)
        };

        await _departmentRepository.CreateAsync(department);
        await _departmentRepository.SaveChangesAsync();

        return department;
    }

    public async Task<Department> UpdateAsync(DepartmentUpdateDto departmentDto)
    {
        Department department = await GetByIdAsync(departmentDto.Id);

        department.Title = departmentDto.Title;
        department.IsDeleted = departmentDto.IsDeleted;
        department.UpdatedAt = DateTime.UtcNow.AddHours(4);

        _departmentRepository.Update(department);
        await _departmentRepository.SaveChangesAsync();

        return department;
    }

    public async Task DeleteAsync(int id)
    {
        Department department = await GetByIdAsync(id);

        _departmentRepository.Delete(department);
        await _departmentRepository.SaveChangesAsync();
    }
}
