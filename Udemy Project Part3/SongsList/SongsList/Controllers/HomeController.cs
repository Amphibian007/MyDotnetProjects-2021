using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SongsList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Controllers
{
    public class HomeController : Controller
    {
        private readonly SongContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, SongContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var songs = _context.Songs.OrderBy(m => m.Name).ToList();
            return View(songs);
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
