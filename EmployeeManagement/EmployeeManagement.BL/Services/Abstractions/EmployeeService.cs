using EmployeeManagement.BL.DTOs;
using EmployeeManagement.BL.Exceptions;
using EmployeeManagement.BL.Services.Implementations;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.DAL.Repositories.Abstractions;

namespace EmployeeManagement.BL.Services.Abstractions;

public class EmployeeService : IEmployeeService
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<Department> _departmentRepository;

    public EmployeeService(IRepository<Employee> employeeRepository, IRepository<Department> departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        Employee? employee =
            await _employeeRepository.GetByIdAsync(id) ??
            throw new EntityNotFoundException();

        employee.Department = employee.DepartmentId is not null ?
            await _departmentRepository.GetByIdAsync((int) employee.DepartmentId) : null;

        return employee;
    }

    public async Task<ICollection<EmployeeListDto>> GetAllAsync()
    {
        ICollection<Employee> employees = await _employeeRepository.GetAllAsync();
        ICollection<EmployeeListDto> employeeListDtos = [];

        foreach (Employee employee in employees)
        {
            employeeListDtos.Add(new EmployeeListDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Job = employee.Job,
                IsDeleted = employee.IsDeleted
            });
        }

        return employeeListDtos;
    }

    public async Task<Employee> CreateAsync(EmployeeCreateDto employeeDto)
    {
        Employee employee = new()
        {
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            Salary = employeeDto.Salary,
            Job = employeeDto.Job,
            ExperienceYear = employeeDto.ExperienceYear,
            IsDeleted = employeeDto.IsDeleted,
            CreatedAt = DateTime.UtcNow.AddHours(4)
        };

        if (employeeDto.DepartmentId is not null)
        {
            Department? department =
                await _departmentRepository.GetByIdAsync((int) employeeDto.DepartmentId) ??
                throw new EntityNotFoundException();
            
            employee.Department = department;
        }

        await _employeeRepository.CreateAsync(employee);
        await _employeeRepository.SaveChangesAsync();

        return employee;
    }

    public async Task<Employee> UpdateAsync(EmployeeUpdateDto employeeDto)
    {
        Employee employee = await GetByIdAsync(employeeDto.Id);

        employee.FirstName = employeeDto.FirstName;
        employee.LastName = employeeDto.LastName;
        employee.Salary = employeeDto.Salary;
        employee.Job = employeeDto.Job;
        employee.ExperienceYear = employeeDto.ExperienceYear;
        employee.DepartmentId = employeeDto.DepartmentId;
        employee.IsDeleted = employeeDto.IsDeleted;
        employee.UpdatedAt = DateTime.UtcNow.AddHours(4);

        if (employeeDto.DepartmentId is not null)
        {
            Department? department =
                await _departmentRepository.GetByIdAsync((int) employeeDto.DepartmentId) ??
                throw new EntityNotFoundException();

            employee.Department = department;
        }

        _employeeRepository.Update(employee);
        await _employeeRepository.SaveChangesAsync();

        return employee;
    }

    public async Task DeleteAsync(int id)
    {
        Employee employee = await GetByIdAsync(id);

        _employeeRepository.Delete(employee);
        await _employeeRepository.SaveChangesAsync();
    }
}
