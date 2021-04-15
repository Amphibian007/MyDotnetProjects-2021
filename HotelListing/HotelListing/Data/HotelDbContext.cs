using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class HotelDbContext:DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options):base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { Id=1,Name="Bangladesh",ShortName="BD"},
                new Country { Id=2,Name="India",ShortName="IN"},
                new Country { Id=3,Name="America",ShortName="USA"}
                );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id=1,
                    Name = "Get Better",                 
                    Address="Gulshan",
                    Rating=3.5,
                    CountryId = 1
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Sun Shine",
                    Address = "Banani",
                    Rating = 4.5,
                    CountryId = 1
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Disco",
                    Address = "Las Vegas",
                    Rating = 4.4,
                    CountryId = 3
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Butterfly",
                    Address = "Mumbai",
                    Rating = 4.6,
                    CountryId = 2
                },
                new Hotel
                {
                    Id = 5,
                    Name = "Rising Up",
                    Address = "Uttara",
                    Rating = 4.7,
                    CountryId = 1
                }
                );
        }
    }
}
