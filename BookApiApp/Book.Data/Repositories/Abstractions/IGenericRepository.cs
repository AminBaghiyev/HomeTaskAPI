using Book.Core.Entities.Base;

namespace Book.Data.Repositories.Abstractions;

public interface IGenericRepository<Tentity> where Tentity : BaseEntity, new()
{
    Task<ICollection<Tentity>> GetAllAsync();
    Task<Tentity> GetByIdAsync(int Id);
    Task<bool> IsExistsAsync(int Id);
    Task<Tentity> CreateAsync(Tentity entity);
    void Update(Tentity entity);
    void SoftDelete(Tentity entity);
    Task<int> SaveChangesAsync();
}
