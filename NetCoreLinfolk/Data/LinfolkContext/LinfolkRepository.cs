using NetCoreLinfolk.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.LinfolkContext
{
    public class LinfolkRepository : ILinfolkRepository
    {
        private readonly LinfolkContext _ctx;

        public LinfolkRepository(LinfolkContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _ctx.Books.OrderByDescending(b=>b.ModifiedDate).ToList();
        }
        
        public IEnumerable<Book> GetBooksByCategory(string category)
        {
            return _ctx.Books.Where(b => b.SubCategory.SubCategoryName.Contains(category)).ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
