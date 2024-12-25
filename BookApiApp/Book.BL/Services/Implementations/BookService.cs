using AutoMapper;
using Book.BL.DTOs.BookDtos;
using Book.BL.Exceptions.CommonExceptions;
using Book.BL.Services.Abstractions;
using Book.Data.Repositories.Abstractions;
using Entities = Book.Core.Entities;

namespace Book.BL.Services.Implementations;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepo;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepo, IMapper mapper)
    {
        _bookRepo = bookRepo;
        _mapper = mapper;
    }
    public async Task<ICollection<Entities.Book>> GetAllAsync()
    {
        return await _bookRepo.GetAllAsync();
    }
    public async Task<Entities.Book> CreateAsync(BookCreateDto entityDto)
    {
        Entities.Book createdBook = _mapper.Map<Entities.Book>(entityDto);
        createdBook.CreatedAt = DateTime.UtcNow.AddHours(4);
        var createdEntity = await _bookRepo.CreateAsync(createdBook);
        await _bookRepo.SaveChangesAsync();
        return createdEntity;
    }

    public async Task<Entities.Book> GetByIdAsync(int id)
    {
        if (!await _bookRepo.IsExistsAsync(id))
        {
             throw new EntityNotFoundException();
        }
        return await _bookRepo.GetByIdAsync(id);

    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var bookEntity = await GetByIdAsync(id);
        _bookRepo.SoftDelete(bookEntity);
         await _bookRepo.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, BookCreateDto bookUpdateDto)
    {
        var bookEntity = await GetByIdAsync(id);
        Entities.Book updatedBook = _mapper.Map<Entities.Book>(bookUpdateDto);
        updatedBook.UpdatedAt = DateTime.UtcNow.AddHours(4);
        updatedBook.Id = id;
        _bookRepo.Update(updatedBook);
        await _bookRepo.SaveChangesAsync();
        return true;

    }

    public async Task<bool> EditAsync(int id, BookEditDto bookEditDto)
    {
        var bookEntity = await GetByIdAsync(id);
        _mapper.Map(bookEditDto, bookEntity);
        
        bookEntity.UpdatedAt = DateTime.UtcNow.AddHours(4);
       
        _bookRepo.Update(bookEntity);
        await _bookRepo.SaveChangesAsync();
        return true;
    }
}
