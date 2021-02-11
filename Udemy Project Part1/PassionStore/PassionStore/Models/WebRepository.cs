using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassionStore.Models
{
    public class WebRepository
    {
        public static List<Website> GetAll()
        {
            var allWebsites = new List<Website>
            {
                new Website
                {
                    Id=1,
                    Name="Google",
                    Price=20
                },
                new Website
                {
                    Id=2,
                    Name="Amazon",
                    Price=30
                },
                 new Website
                 {
                    Id=3,
                    Name="Microsoft",
                    Price=50
                 },
                  new Website
                {
                    Id=4,
                    Name="Foodpanda",
                    Price=60
                } ,
                  new Website
                {
                    Id=5,
                    Name="Apple",
                    Price=20
                } ,
                  new Website
                {
                    Id=6,
                    Name="Product Of The Month",
                    Price=20
                },
                new Website
                {
                    Id=6,
                    Name="Machintosh",
                    Price=20
                }
            };
            return allWebsites;
        }
        public static Website GetById(string slug)
        {
            List<Website> websites = WebRepository.GetAll();
            foreach(var website in websites)
            {
                if (website.Slug == slug)
                {
                    return website;
                }
               
            }
            return null;
        }
    }
}
