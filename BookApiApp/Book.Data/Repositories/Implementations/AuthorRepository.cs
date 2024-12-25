using Book.Core.Entities;
using Book.Data.DAL;
using Book.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Data.Repositories.Implementations
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }
    }
}
