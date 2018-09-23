using Microsoft.AspNetCore.Hosting;
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
        public LinfolkSeeder(LinfolkContext ctx, IHostingEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Countries.Any())
            {
                //need to create sample data
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data/SeedData/art.json");
                var json = File.ReadAllText(filepath);
                var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(json);
                _ctx.Categories.AddRange(categories);
            }

            _ctx.SaveChanges();
        }
    }
}
