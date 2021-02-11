using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareeStore.Models
{
    public class Sharee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string slugLink => Name.Replace(' ', '-');
    }
}
