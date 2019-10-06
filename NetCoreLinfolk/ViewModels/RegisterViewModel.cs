using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreLinfolk.Data.LinfolkContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(4)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string PhoneNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
        [MinLength(8)]
        public string ConfirmPassword { get; set; }

    }
}
