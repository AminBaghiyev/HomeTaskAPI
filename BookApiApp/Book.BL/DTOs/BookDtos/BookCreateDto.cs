using FluentValidation;

namespace Book.BL.DTOs.BookDtos;

public record BookCreateDto
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int AuthorId { get; set; }
}
public class BookCreateDtoValidation : AbstractValidator<BookCreateDto>
{
    public BookCreateDtoValidation()
    {
        RuleFor(b => b.Title).NotEmpty()
        .WithMessage("Title cannot be empty")
        .NotNull().WithMessage("Title cannot be null")
        .MaximumLength(128).WithMessage("Maximum length is 128");

        RuleFor(b => b.Price).NotEmpty().NotNull()
            .WithMessage("Price cannot be null or empty")
            //.ExclusiveBetween(0,1000).WithMessage("Book price can not be below 0 or above 1000")
            .GreaterThan(0).WithMessage(" Price can not be below 0");

        RuleFor(b => b.Quantity).NotEmpty().NotNull()
            .WithMessage("Quantity cannot be null or empty")
            .GreaterThan(0).WithMessage(" Quantity can not be below 0");
    }
}
