using NetCoreLinfolk.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.LinfolkContext
{
    public interface ILinfolkRepository
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByCategory(string category);
        bool SaveAll();
    }
}
