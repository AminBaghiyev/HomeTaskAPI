using Book.BL.DTOs.AuthorDtos;
using Book.Core.Entities;

namespace Book.BL.Services.Abstractions;

public interface IAuthorService
{
    Task<Author> CreateAsync(AuthorCreateDto entityDto);
    Task<ICollection<AuthorListItemDto>> GetAllAsync();
}
