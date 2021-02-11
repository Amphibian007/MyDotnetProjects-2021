using LaptopStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Controllers
{
    public class LaptopController : Controller
    {
        public IActionResult Index()
        {
            var laptops = LaptopRepository.GetAll();
            return View(laptops);
        }
        public IActionResult Details(int id)
        {
            var laptop = LaptopRepository.GetSingleLaptop(id);
            return View(laptop);
        }
    }
}
