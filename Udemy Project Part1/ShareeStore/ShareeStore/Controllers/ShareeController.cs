using Microsoft.AspNetCore.Mvc;
using ShareeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareeStore.Controllers
{
    public class ShareeController : Controller
    {
        public IActionResult Index()
        {
            var sharees = ShareeRepository.GetAll();
            return View(sharees);
        }
        public IActionResult Details(string slug)
        {
            var sharee = ShareeRepository.GetSingleItem(slug);
            return View(sharee);
        }
    }
}
