namespace Book.BL.DTOs.AuthorDtos;

public record AuthorListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}
