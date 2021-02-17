using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Models
{
    public class SongContext : DbContext
    {
        public SongContext(DbContextOptions<SongContext> options) : base(options)
        {

        }
        public DbSet<Song> Songs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
               new Song
               {
                   Id=1,
                   Name="Pal pal",
                   Rating=5,
                   Year=2002
               },
               new Song
                {
                    Id = 2,
                    Name = "Bhoolbhulaiya",
                    Rating = 4,
                    Year = 2001
                }
                );
        }
    }
}
