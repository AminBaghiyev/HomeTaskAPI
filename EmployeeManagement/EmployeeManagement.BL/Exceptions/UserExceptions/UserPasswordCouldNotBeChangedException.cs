namespace EmployeeManagement.BL.Exceptions;

public class UserPasswordCouldNotBeChangedException : Exception
{
    public UserPasswordCouldNotBeChangedException(string message) : base(message) { }

    public UserPasswordCouldNotBeChangedException() : base("The user's password could not be changed!") { }
}
