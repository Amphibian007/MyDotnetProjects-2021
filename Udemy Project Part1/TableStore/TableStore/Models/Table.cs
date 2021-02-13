using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableStore.Models
{
    public class Table
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string LinkName => Name.Replace(' ', '-');
    }
}
