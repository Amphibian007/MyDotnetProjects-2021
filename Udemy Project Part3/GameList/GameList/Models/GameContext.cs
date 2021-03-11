using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameList.Models
{
    public class GameContext:DbContext
    {
        public GameContext(DbContextOptions<GameContext> options):base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Name = "NFS",
                    Year = 2010,
                    Rating = 3
                },
                new
                {
                    Id=2,
                    Name="COC",
                    Year=2001,
                    Rating=4
                }
            );
        }
    }
}
