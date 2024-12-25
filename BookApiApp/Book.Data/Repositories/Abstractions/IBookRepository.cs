using Entities = Book.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Data.Repositories.Abstractions
{
    public interface IBookRepository : IGenericRepository<Entities.Book>
    {
        
    }
}
