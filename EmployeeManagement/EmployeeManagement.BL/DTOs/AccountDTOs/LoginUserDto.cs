using FluentValidation;

namespace EmployeeManagement.BL.DTOs;

public record LoginUserDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginUserDtoValidation : AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidation()
    {
        RuleFor(e => e.Username)
            .NotEmpty().NotNull().WithMessage("Username cannot be empty!")
            .MinimumLength(5).WithMessage("Username must be at least 5 symbols long!");

        RuleFor(e => e.Password)
            .NotEmpty().NotNull().WithMessage("The password cannot be empty!")
            .MinimumLength(4).WithMessage("The password must be at least 4 symbols long!");
    }
}