using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Boolean IsEnabled { get; set; }

        public ICollection<Book> Books { get; set; } 
    }
}
