using Microsoft.AspNetCore.Mvc;
using MobileList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileList.Controllers
{  
    public class MobileController : Controller
    {
        private readonly MobileContext _context;

        public MobileController(MobileContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            ViewBag.Companies = _context.Companies.OrderBy(m => m.Name).ToList();
            return View("Edit",new Mobile());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var mobile = _context.Mobiles.Find(id);
            ViewBag.Companies = _context.Companies.OrderBy(m => m.Name).ToList();
            return View(mobile);
        }
        [HttpPost]
        public IActionResult Edit(Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                if (mobile.Id == 0)
                {
                    _context.Mobiles.Add(mobile);
                }
                else
                {
                    _context.Mobiles.Update(mobile);
                }
                _context.SaveChanges();
            }
            else
            {
                ViewBag.Action = mobile.Id == 0 ? "Create" : "Edit";
                ViewBag.Companies = _context.Companies.OrderBy(m => m.Name).ToList();
                return View(mobile);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var mobile = _context.Mobiles.Find(id);
            return View(mobile);
        }
        [HttpPost]
        public IActionResult Delete(Mobile mobile)
        {
            _context.Mobiles.Remove(mobile);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
