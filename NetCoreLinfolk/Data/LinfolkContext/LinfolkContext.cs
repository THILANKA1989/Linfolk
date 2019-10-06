using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCoreLinfolk.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data.LinfolkContext
{
    public class LinfolkContext : IdentityDbContext<Author>
    {

        public LinfolkContext(DbContextOptions<LinfolkContext> options ): base(options)
        {
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCover> BookCovers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(new Country()
            {
                Id = 1,
                CountryName = "Sri Lanka",
                IsEnabled = true
            });

            modelBuilder.Entity<City>().HasData(new City()
            {
                Id = 1,
                CityName = "Colombo",
                CountryId = 1,
                IsEnabled = true
            });
        }
    }
}
