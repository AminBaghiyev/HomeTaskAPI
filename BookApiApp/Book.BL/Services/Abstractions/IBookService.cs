using Book.BL.DTOs.BookDtos;
using Entities = Book.Core.Entities;

namespace Book.BL.Services.Abstractions;

public interface IBookService 
{
    Task<ICollection<Entities.Book>> GetAllAsync();
    Task<Entities.Book> CreateAsync(BookCreateDto entityDto);
    Task<Entities.Book> GetByIdAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> UpdateAsync(int id, BookCreateDto entityDto);
    Task<bool> EditAsync(int id, BookEditDto entityDto);
}
