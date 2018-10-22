using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.Entities
{
    public class Author : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinedDate { get; set; }
        public Boolean IsActivated { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public City City { get; set; }
        public int UserType { get; set; }

        public ICollection<Book> Books { get; set; } 
    }
}
