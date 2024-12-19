namespace EmployeeManagement.BL.DTOs;

public record DepartmentCreateDto
{
    public string Title { get; set; }
    public bool IsDeleted { get; set; }
}
