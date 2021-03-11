using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStore.Models
{
    public class TreeDbContext : DbContext
    {
        public TreeDbContext(DbContextOptions<TreeDbContext> options) : base(options)
        {

        }
        public DbSet<Tree> Trees { get; set; }
        public DbSet<Type> Types { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Type>().HasData(
                new Type
                {
                    TypeId = 1,
                    Name = "Summer"
                },
                new Type
                {
                    TypeId = 2,
                    Name = "Winter"
                },
                new Type
                {
                    TypeId = 3,
                    Name = "Spring"
                },
                new Type
                {
                    TypeId = 4,
                    Name = "Rainy"
                },
                new Type
                {
                    TypeId = 5,
                    Name = "All Season"
                }
                );

            modelBuilder.Entity<Tree>().HasData(
                new Tree
                {
                    TreeId = 1,
                    Name = "Mango Tree",
                    Year = 2001,
                    Rating = 4,
                    TypeId=1
                },
                 new Tree
                 {
                     TreeId = 2,
                     Name = "Cocunut Tree",
                     Year = 2010,
                     Rating = 3,
                     TypeId = 2
                 },
                  new Tree
                  {
                      TreeId = 3,
                      Name = "Banyan Tree",
                      Year = 2020,
                      Rating = 5,
                      TypeId = 3
                  },
                   new Tree
                   {
                       TreeId = 4,
                       Name = "Berry Tree",
                       Year = 2015,
                       Rating = 3,
                       TypeId = 2
                   },
                    new Tree
                    {
                        TreeId = 5,
                        Name = "Jackfruit Tree",
                        Year = 2010,
                        Rating = 5,
                        TypeId = 2
                    }
              );
        }
    }
}
