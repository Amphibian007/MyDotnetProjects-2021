using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SumCalculator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SumCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Result = "";
            return View();
        }
        [HttpPost]
        public IActionResult Index(Digit value)
        {
            if (ModelState.IsValid)
            {
                if (value.Operation == "+")
                {
                    ViewBag.Result = value.Sum().ToString("c2");
                }
                else if (value.Operation == "-")
                {
                    ViewBag.Result = value.Sub().ToString("c2");
                }
                else if (value.Operation == "*")
                {
                    ViewBag.Result = value.Mul().ToString("c2");
                }
                else if (value.Operation == "/")
                {
                    ViewBag.Result = value.Div().ToString("c2");
                }
            }
            else
            {
                ViewBag.Result = "";
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
