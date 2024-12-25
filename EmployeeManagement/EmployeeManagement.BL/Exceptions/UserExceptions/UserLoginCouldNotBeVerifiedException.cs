namespace EmployeeManagement.BL.Exceptions;

public class UserLoginCouldNotBeVerifiedException : Exception
{
    public UserLoginCouldNotBeVerifiedException(string message) : base(message) { }

    public UserLoginCouldNotBeVerifiedException() : base("Username or password is invalid!") { }
}
