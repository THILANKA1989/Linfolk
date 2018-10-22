using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public Boolean IsEnabled { get; set; }

        public ICollection<City> Cities { get; set; } 
    }
}
