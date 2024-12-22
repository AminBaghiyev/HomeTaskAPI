namespace EmployeeManagement.BL.Exceptions;

public class UserExistsException : Exception
{
    public UserExistsException(string message) : base(message) { }

    public UserExistsException() : base("The user already exists") { }
}
