using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public Boolean IsEnabled { get; set; }

        public Category Category { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
