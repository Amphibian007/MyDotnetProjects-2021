using Microsoft.AspNetCore.Mvc;
using SportsList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsList.Controllers
{
    public class SportController : Controller
    {
        private readonly SportContext _context;

        public SportController(SportContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            ViewBag.Types = _context.Types.OrderBy(m => m.Name).ToList(); 
            return View("Edit",new Sport());
        }

        [HttpGet]
        public IActionResult Edit(int id )
        {
            ViewBag.Action = "Edit";
            ViewBag.Types = _context.Types.OrderBy(m => m.Name).ToList();
            var sport = _context.Sports.Find(id);
            return View(sport);
        }
        [HttpPost]
        public IActionResult Edit(Sport sport)
        {
            if (ModelState.IsValid)
            {
                if (sport.Id == 0)
                {
                    _context.Sports.Add(sport);
                }
                else
                {
                    _context.Sports.Update(sport);
                }
                _context.SaveChanges();
            }
            else
            {
                ViewBag.Action = sport.Id == 0 ? "Create" : "Edit";
                ViewBag.Types = _context.Types.OrderBy(m => m.Name).ToList();
                return View(sport);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sport = _context.Sports.Find(id);
            return View(sport);
        }
        [HttpPost]
        public IActionResult Delete(Sport sport)
        {
            _context.Sports.Remove(sport);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
