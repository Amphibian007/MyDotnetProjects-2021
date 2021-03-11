using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobliePhoneList.Models
{
    public class MobileContext:DbContext
    {
        public MobileContext(DbContextOptions<MobileContext> options):base(options)
        {

        }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<Company> Companies { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company { CompanyId=1,Name="Xiaomi"},
                new Company { CompanyId=2,Name="Samsung"},
                new Company { CompanyId=3,Name="Nokia"},
                new Company { CompanyId=4, Name = "IPhone" }
                );
            modelBuilder.Entity<Mobile>().HasData(
                new Mobile
                {
                    Id=1,
                    Name="Redmi note 7",
                    Price=16000,
                    Rating=4,
                    CompanyId=1
                },
                new Mobile
                {
                    Id = 2,
                    Name = "Pro Device",
                    Price = 15000,
                    Rating = 3,
                    CompanyId=2
                },
                new Mobile
                {
                    Id = 3,
                    Name = "Iphone 12",
                    Price = 160000,
                    Rating = 5,
                    CompanyId=4
                }

                );
        }
    }
}
