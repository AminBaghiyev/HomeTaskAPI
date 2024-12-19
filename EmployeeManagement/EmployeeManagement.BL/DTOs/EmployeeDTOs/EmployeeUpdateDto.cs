using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.BL.DTOs;

public record EmployeeUpdateDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal Salary { get; set; }
    public string Job { get; set; }
    public int ExperienceYear { get; set; }
    public int? DepartmentId { get; set; }
    public bool IsDeleted { get; set; }
}
