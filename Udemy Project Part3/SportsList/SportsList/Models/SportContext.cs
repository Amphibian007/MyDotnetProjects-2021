using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsList.Models
{
    public class SportContext:DbContext
    {
        public SportContext(DbContextOptions<SportContext> options):base(options)
        {
                
        }
        public DbSet<Sport> Sports { get;set; }
        public DbSet<Type> Types { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Type>().HasData(
                new Type { TypeId=1,Name="Indoor"},
                new Type { TypeId=2,Name="Outdoor"},
                new Type { TypeId=3,Name="Mobile"},
                new Type { TypeId=4,Name="PC"},
                new Type { TypeId=5,Name="Console"}
                );
            modelbuilder.Entity<Sport>().HasData(
                new Sport
                {
                    Id=1,
                    Name="Ludu",
                    Price=50,
                    TypeId=1,
                    Rating=5
                },
                new Sport
                {
                    Id = 2,
                    Name = "Football",
                    Price = 1000,
                    TypeId = 2,
                    Rating = 5
                },
                new Sport
                {
                    Id = 3,
                    Name = "Fifa 20",
                    Price = 20000,
                    TypeId = 5,
                    Rating = 4
                }
                );
        }
    }
}
