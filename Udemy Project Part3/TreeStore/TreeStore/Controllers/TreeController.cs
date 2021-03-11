using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStore.Models;

namespace TreeStore.Controllers
{
    public class TreeController : Controller
    {
        private readonly TreeDbContext _dbContext;

        public TreeController(TreeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            return View("Edit",new Tree());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var tree = _dbContext.Trees.Find(id);
            return View(tree);
        }
        [HttpPost]
        public IActionResult Edit(Tree tree)
        {
            if (ModelState.IsValid)
            {
                if (tree.TreeId == 0)
                {
                    _dbContext.Trees.Add(tree);
                }
                else
                {
                    _dbContext.Trees.Update(tree);
                }
                _dbContext.SaveChanges();
              
            }
            else
            {
                ViewBag.Action = tree.TreeId == 0 ? "Create" : "Update";
                return View(tree);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Action = "Delete";
            var tree = _dbContext.Trees.Find(id);
            return View(tree);
        }
        [HttpPost]
        public IActionResult Delete(Tree tree)
        {          
            _dbContext.Trees.Remove(tree);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
       
    }
}
