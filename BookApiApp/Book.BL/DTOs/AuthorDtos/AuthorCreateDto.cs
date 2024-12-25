using FluentValidation;

namespace Book.BL.DTOs.AuthorDtos;

public class AuthorCreateDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
   
}
public class AuthorCreateDtoValidation : AbstractValidator<AuthorCreateDto>
{
    public AuthorCreateDtoValidation()
    {
        RuleFor(b => b.Name).NotEmpty()
        .WithMessage("Name cannot be empty")
        .NotNull().WithMessage("Name cannot be null")
        .MaximumLength(128).WithMessage("Maximum length is 128");

        RuleFor(b => b.Surname).NotEmpty()
       .WithMessage("Surname cannot be empty")
       .NotNull().WithMessage("Surname cannot be null")
       .MaximumLength(128).WithMessage("Surname Maximum length is 128");

    }
}
