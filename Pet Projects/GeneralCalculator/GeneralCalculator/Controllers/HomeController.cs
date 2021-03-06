using GeneralCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GeneralCalculator.Controllers
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
        public IActionResult Index(CalculateModel value)
        {
            if (ModelState.IsValid)
            {
                if (value.Operation == "Sum")
                    ViewBag.Result = value.Add().ToString();
                else if (value.Operation == "Subtraction")
                    ViewBag.Result = value.Sub().ToString();
                else if (value.Operation == "Multiplication")
                    ViewBag.Result = value.Mul().ToString();
                else if (value.Operation == "Divisioin")
                    ViewBag.Result = value.Div().ToString();
                
            }
            else
            {
                ViewBag.Result = "Enter operation correctly";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
