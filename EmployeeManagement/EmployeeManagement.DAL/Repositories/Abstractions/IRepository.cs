using EmployeeManagement.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Repositories.Abstractions;

public interface IRepository<T> where T : BaseEntity, new()
{
    Task<T?> GetByIdAsync(int id);
    Task<ICollection<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    T Update(T entity);
    void Delete(T entity);
    Task<int> SaveChangesAsync();
}
