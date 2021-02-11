using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Models
{
    public class LaptopRepository
    {
        public static List<Laptop> GetAll()
        {
            List<Laptop> allLaptops = new List<Laptop>()
            {
                new Laptop()
                {
                    Id=1,
                    ModelName="Probook 450 G4",
                    Company="HP",
                    Price=52000
                },
                new Laptop()
                {
                    Id=2,
                    ModelName="Prob G4",
                    Company="HP",
                    Price=48000
                },
                new Laptop()
                {
                    Id=3,
                    ModelName="Delight 45",
                    Company="Apple",
                    Price=152000
                },
                new Laptop()
                {
                    Id=4,
                    ModelName="Laptop of the week",
                    Company="HP",
                    Price=52000
                },
                new Laptop()
                {
                    Id=5,
                    ModelName="Spicy 78",
                    Company="Samsung",
                    Price=38000
                },
            };
            return allLaptops;
        }
        public static Laptop GetSingleLaptop(int id)
        {
            var laptops = LaptopRepository.GetAll();
            foreach(var item in laptops)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
