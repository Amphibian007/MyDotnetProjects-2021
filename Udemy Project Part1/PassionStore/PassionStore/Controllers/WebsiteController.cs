using Microsoft.AspNetCore.Mvc;
using PassionStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassionStore.Controllers
{
    public class WebsiteController : Controller
    {
        public IActionResult Details(string slugLink)
        {
            var website = WebRepository.GetById(slugLink);
            return View(website);
        }
        public IActionResult ListOFWebsite()
        {
            var websites = WebRepository.GetAll();
            return View(websites);
        }
    }
}
