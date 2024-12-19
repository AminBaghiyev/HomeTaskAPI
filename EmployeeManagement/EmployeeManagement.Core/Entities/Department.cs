using EmployeeManagement.Core.Entities.Base;

namespace EmployeeManagement.Core.Entities;

public class Department : BaseAuditableEntity
{
    public string Title { get; set; }
    public ICollection<Employee> Employees { get; set; }
}
