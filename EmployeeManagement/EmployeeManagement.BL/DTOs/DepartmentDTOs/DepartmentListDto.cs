namespace EmployeeManagement.BL.DTOs;

public record DepartmentListDto
{
    public int Id { get; init; }
    public string Title { get; init; }
    public bool IsDeleted { get; init; }
}
