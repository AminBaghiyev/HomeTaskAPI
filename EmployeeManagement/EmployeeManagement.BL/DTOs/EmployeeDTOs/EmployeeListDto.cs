namespace EmployeeManagement.BL.DTOs;

public record EmployeeListDto
{
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Job { get; init; }
    public bool IsDeleted { get; init; }
}
