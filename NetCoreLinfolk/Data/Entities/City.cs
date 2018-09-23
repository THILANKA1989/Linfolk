using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string PostalZip { get; set; }
        public Boolean IsEnabled { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        public ICollection<Book> Books { get; set; }  
    }
}
