using NetCoreLinfolk.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.LinfolkContext
{
    public interface ILinfolkRepository
    {
        //categories
        IEnumerable<Category> GetCategories();
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByCategory(string category);
        IEnumerable<SubCategory> GetAllSubCategories();
        bool SaveAll();
        Category GetCategoryById(int id);
        void AddEntity(object model);
    }
}
