namespace EmployeeManagement.BL.Exceptions;

public class UserEmailCouldNotBeVerifiedException : Exception
{
    public UserEmailCouldNotBeVerifiedException(string message) : base(message) { }

    public UserEmailCouldNotBeVerifiedException() : base("The user's mail could not be verified!") { }
}
