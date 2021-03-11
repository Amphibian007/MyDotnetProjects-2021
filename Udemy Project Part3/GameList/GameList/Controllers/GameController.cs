using GameList.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameList.Controllers
{
    public class GameController : Controller
    {
        private readonly GameContext _context;

        public GameController(GameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            return View("Edit",new Game());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var game = _context.Games.Find(id);
            return View(game);
        }
        [HttpPost]
        public IActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                if (game.Id == 0)
                {
                    _context.Games.Add(game);
                }
                else
                {
                    _context.Games.Update(game);
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = game.Id == 0 ? "Create" : "Edit";
                return View(game);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var game = _context.Games.Find(id);
            return View(game);
        }
        [HttpPost]
        public IActionResult Delete(Game game)
        {
            _context.Games.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
