using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId=1,Name="Action"},
                new Genre { GenreId=2,Name="Thriller"},
                new Genre { GenreId=3,Name="Romantic"},
                new Genre { GenreId=4,Name="Horror"},
                new Genre { GenreId=5,Name="Comedy"}
                );
            modelBuilder.Entity<Movie>().HasData(
                new Movie { 
                    MovieId=1,
                    Name="Ghajini",
                    Year="2009",
                    Rating=8,
                    GenreId=1
                },
                new Movie
                {
                    MovieId = 2,
                    Name = "Don",
                    Year = "2005",
                    Rating = 6,
                    GenreId = 1
                },
                new Movie
                {
                    MovieId = 3,
                    Name = "3 Idiots",
                    Year = "2010",
                    Rating = 9,
                    GenreId = 5
                }
                );
        }
    }
}
