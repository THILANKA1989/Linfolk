using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string country_name { get; set; }
        public Boolean is_enabled { get; set; }

        public ICollection<City> Cities { get; set; } 
    }
}
