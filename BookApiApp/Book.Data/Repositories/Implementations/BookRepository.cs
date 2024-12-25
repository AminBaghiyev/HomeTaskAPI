using Book.Data.Repositories.Abstractions;
using Entities = Book.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Data.DAL;

namespace Book.Data.Repositories.Implementations
{
    public class BookRepository : GenericRepository<Entities.Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
