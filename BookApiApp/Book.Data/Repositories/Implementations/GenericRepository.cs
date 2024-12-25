using Book.Core.Entities.Base;
using Book.Data.DAL;
using Book.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.Data.Repositories.Implementations
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        
        DbSet<Tentity> table => _context.Set<Tentity>();
        public async Task<ICollection<Tentity>> GetAllAsync()
        {
           return await table.Where(x=>!x.IsDeleted).ToListAsync();
        }
        

        public async Task<Tentity> CreateAsync(Tentity entity)
        {
           await table.AddAsync(entity);
           return entity;
        }
        public async Task<Tentity> GetByIdAsync(int Id)
        {
           var entity = await table.FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);  
           _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public void Update(Tentity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void SoftDelete(Tentity entity)
        {
            entity.IsDeleted = true;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistsAsync(int Id)
        {
            return await table.AnyAsync(x => x.Id == Id && !x.IsDeleted);
        }
    }
}
