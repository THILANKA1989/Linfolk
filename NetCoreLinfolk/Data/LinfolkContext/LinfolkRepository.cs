using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<LinfolkRepository> _logger;

        public LinfolkRepository(LinfolkContext ctx, ILogger<LinfolkRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _ctx.Categories.Include(o => o.SubCategories).OrderBy(b => b.CategoryName).ToList();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _ctx.Books.OrderByDescending(b => b.ModifiedDate).ToList();
        }

        public IEnumerable<Book> GetBooksByCategory(string category)
        {
            return _ctx.Books.Where(b => b.SubCategory.SubCategoryName.Contains(category)).ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public IEnumerable<SubCategory> GetAllSubCategories()
        {
            return _ctx.SubCategories.OrderBy(s => s.Description).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _ctx.Categories.Include(o => o.SubCategories).Where(a => a.Id == id).FirstOrDefault();
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public List<DropDown> GetCitiesDropdown()
        {
            List<DropDown> citiesList = new List<DropDown>();
            foreach(var i in _ctx.Cities.ToList())
            {
                DropDown city = new DropDown();
                city.Text = i.CityName;
                city.Value = i.Id;
                citiesList.Add(city);
            }
            return citiesList;
        }
    }

    public class DropDown{
        public int Value { get; set; }
        public string Text { get; set; }
    }
}
