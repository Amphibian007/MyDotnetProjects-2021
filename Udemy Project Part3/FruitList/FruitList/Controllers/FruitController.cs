using FruitList.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitList.Controllers
{
    public class FruitController : Controller
    {
        private readonly FruitContext _context;

        public FruitController(FruitContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            ViewBag.Genres = _context.Genres.OrderBy(m => m.Name).ToList();
            return View("Edit",new Fruit());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = _context.Genres.OrderBy(m => m.Name).ToList();
            ViewBag.Action = "Edit";
            var fruit = _context.Fruits.Find(id);
            return View(fruit);
        }
        [HttpPost]
        public IActionResult Edit(Fruit fruit)
        {
            if (ModelState.IsValid)
            {
                if (fruit.Id == 0)
                {
                    _context.Fruits.Add(fruit);
                }
                else
                {
                    _context.Fruits.Update(fruit);
                }
                _context.SaveChanges();
            }
            else
            {
                ViewBag.Action = fruit.Id == 0 ? "Create" : "Edit";
                ViewBag.Genres = _context.Genres.OrderBy(m => m.Name).ToList();
                return View(fruit);
            }
            return RedirectToAction("Index", "Home");
           
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var fruit = _context.Fruits.Find(id);
            return View(fruit);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var fruit = _context.Fruits.Find(id);
            return View(fruit);
        }
        [HttpPost]
        public IActionResult Delete(Fruit fruit)
        {
            _context.Fruits.Remove(fruit);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
