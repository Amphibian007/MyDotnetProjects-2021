using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareeStore.Models
{
    public class ShareeRepository
    {
        public static List<Sharee> GetAll()
        {
            List<Sharee> allSharees = new List<Sharee>()
        {
            new Sharee
            {
                Id=1,
                Name="Jamdani",
                Category="Homemade"
            },
            new Sharee
            {
                Id=2,
                Name="Tati",
                Category="Tangail"
            },
            new Sharee
            {
                Id=3,
                Name="Silk",
                Category="Indian"
            },
            new Sharee
            {
                Id=4,
                Name="Khadi",
                Category="Comilla"
            },
             new Sharee
            {
                Id=4,
                Name="Sharee of the day",
                Category="Comilla"
            }
        };
            return allSharees;
        }

        public static Sharee GetSingleItem(string slug)
        {
            var sharees = ShareeRepository.GetAll();
            foreach(var item in sharees)
            {
                if (item.slugLink == slug)
                {
                    return item;
                }                
            }
            return null ;
        }
    }
}
