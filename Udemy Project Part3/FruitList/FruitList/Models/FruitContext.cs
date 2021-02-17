using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitList.Models
{
    public class FruitContext:DbContext
    {
        public FruitContext(DbContextOptions<FruitContext> options):base(options)
        {
                
        }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre
                {
                    GenreId="S",
                    Name="Summer"
                },
                new Genre
                {
                    GenreId = "R",
                    Name = "Rainy Season"
                },
                new Genre
                {
                    GenreId = "A",
                    Name = "All Season"

                }
                );
            modelBuilder.Entity<Fruit>().HasData(
                new Fruit
                {
                    Id = 1,
                    Name = "Banana",
                    Year = 2008,
                    Rating = 3,
                    GenreId="A"
                },
                new Fruit
                {
                    Id = 2,
                    Name = "Jack Fruit",
                    Year = 2005,
                    Rating = 4,
                    GenreId="S"
                }
                );
        }
    }
}
