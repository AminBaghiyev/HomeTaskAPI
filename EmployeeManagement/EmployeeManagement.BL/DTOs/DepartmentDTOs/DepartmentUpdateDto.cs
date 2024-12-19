namespace EmployeeManagement.BL.DTOs;

public record DepartmentUpdateDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsDeleted { get; set; }
}
