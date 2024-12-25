namespace Book.BL.DTOs.BookDtos;

public record BookEditDto
{
    public string? Title { get; set; }
    public decimal? Price { get; set; }
    public int? Quantity { get; set; }
    public int? AuthorId { get; set; }
}
