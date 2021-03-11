using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _dbContext;

        public MovieController(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            ViewBag.Genres = _dbContext.Genres.OrderBy(m => m.Name).ToList();
            return View("Edit",new Movie());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = _dbContext.Genres.OrderBy(m => m.Name).ToList();
            var movie = _dbContext.Movies.Find(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (movie.MovieId == 0)
                {
                    _dbContext.Movies.Add(movie);
                }
                else
                {
                    _dbContext.Movies.Update(movie);
                }
                _dbContext.SaveChanges();
            }
            else
            {
                ViewBag.Action = movie.MovieId == 0 ? "Create" : "Edit";
                ViewBag.Genres = _dbContext.Genres.OrderBy(m => m.Name).ToList();
                return View(movie);
            }
            return RedirectToAction("Index", "Home");
        }
       
        public IActionResult Delete(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
       
    }
}
