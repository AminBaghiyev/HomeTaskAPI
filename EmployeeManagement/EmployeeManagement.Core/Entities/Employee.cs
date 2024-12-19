using EmployeeManagement.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Core.Entities;

public class Employee : BaseAuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal Salary { get; set; }
    public string Job { get; set; }
    public int ExperienceYear { get; set; }
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
}
