using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobliePhoneList.Models
{
    public class Mobile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
