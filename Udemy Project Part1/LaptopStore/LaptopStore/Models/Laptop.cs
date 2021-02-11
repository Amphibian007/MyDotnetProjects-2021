using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Models
{
    public class Laptop
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string Company { get; set; }
        public double Price { get; set; }
    }
}
