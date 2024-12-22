namespace EmployeeManagement.BL.Exceptions;

public class UserCouldNotBeCreatedException : Exception
{
    public UserCouldNotBeCreatedException(string message) : base(message) { }

    public UserCouldNotBeCreatedException() : base("The user could not be created!") { }
}
