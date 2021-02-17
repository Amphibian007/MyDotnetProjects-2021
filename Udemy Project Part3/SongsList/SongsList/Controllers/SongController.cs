using Microsoft.AspNetCore.Mvc;
using SongsList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongsList.Controllers
{
    public class SongController : Controller
    {
        public readonly SongContext _context;

        public SongController(SongContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            return View("Edit",new Song());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var song = _context.Songs.Find(id);
            return View(song);
        }
        [HttpPost]
        public IActionResult Edit(Song song)
        {
            if (ModelState.IsValid)
            {
                if (song.Id == 0)
                {
                    _context.Songs.Add(song);
                }
                else
                {
                    _context.Songs.Update(song);
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = song.Id == 0 ? "Create" : "Edit";
                return View(song);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var song = _context.Songs.Find(id);
            return View(song);
        }
        [HttpPost]
        public IActionResult Delete(Song song)
        {
            _context.Songs.Remove(song);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
