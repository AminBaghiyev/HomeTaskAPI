using EmployeeManagement.Core.Entities.Base;
using EmployeeManagement.DAL.Contexts;
using EmployeeManagement.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    protected AppDbContext _context { get; set; }
    protected DbSet<T> _table => _context.Set<T>();

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<T>> GetAllAsync() => await _table.ToListAsync();

    public async Task<T?> GetByIdAsync(int id) => await _table.FindAsync(id);

    public async Task<T> CreateAsync(T entity)
    {
        await _table.AddAsync(entity);
        return entity;
    }

    public T Update(T entity)
    {
        _table.Update(entity);
        return entity;
    }

    public void Delete(T entity) => _table.Remove(entity);

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
