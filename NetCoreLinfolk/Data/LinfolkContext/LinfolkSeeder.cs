using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using NetCoreLinfolk.Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.LinfolkContext
{
    public class LinfolkSeeder
    {
        private readonly LinfolkContext _ctx;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<Author> _userManager;

        public LinfolkSeeder(LinfolkContext ctx, IHostingEnvironment hosting, UserManager<Author> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Countries.Any())
            {
                var country = new Country()
                {
                    CountryName = "Sri Lanka",
                    IsEnabled = true
                };

                _ctx.Countries.Add(country);
                _ctx.SaveChanges();
            }

            if (!_ctx.Cities.Any())
            {
                var countryId = _ctx.Countries.FirstOrDefault().Id;
                var cities = new City()
                {
                    CityName = "Colombo",
                    CountryId = countryId,
                    IsEnabled = true
                };

                _ctx.Cities.Add(cities);
                _ctx.SaveChanges();
            }

            _ctx.SaveChanges();

            var user = await _userManager.FindByEmailAsync("thilankaranasinghe1989@gmail.com");
            if(user == null)
            {
                var cityId = _ctx.Cities.FirstOrDefault().Id;
                user = new Author()
                {
                    FirstName = "Thilanka",
                    LastName = "Ranasinghe",
                    UserName = "thilanka1989",
                    CityId = cityId,
                    Email = "thilankaranasinghe1989@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "Pathfinder1989");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default user");
                }
            }
           
            _ctx.SaveChanges();
        }
    }
}
