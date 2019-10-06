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
            try
            {
                _ctx.Database.EnsureCreated();

                var user = await _userManager.FindByEmailAsync("thilankaranasinghe1989@gmail.com");
                if (user == null)
                {

                    user = new Author()
                    {
                        FirstName = "Thilanka",
                        LastName = "Ranasinghe",
                        UserName = "thilanka1989",
                        CityId = 1,
                        Email = "thilankaranasinghe1989@gmail.com"
                    };

                    IdentityResult result = await _userManager.CreateAsync(user, "Pathfinder!(*(921");
                    if (!result.Succeeded)
                    {
                        throw new Exception("No users were created");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
