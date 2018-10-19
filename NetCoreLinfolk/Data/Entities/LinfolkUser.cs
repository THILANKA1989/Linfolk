using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.Entities
{
    public class LinfolkUser : IdentityUser
    {
        public string FirstName { get; set; }
    }
}
