using Microsoft.AspNetCore.Mvc;
using ProductStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ShopContext _dbContext;

        public CategoryController(ShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List","Category");
        }
        [Route("[area]/Categories/{id?}")]
        public IActionResult List()
        {
            var categories = _dbContext.Categories.OrderBy(c => c.CategoryID).ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddUpdate",new Category());
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            var category = _dbContext.Categories.Find(id);
            return View("AddUpdate", category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.CategoryID == 0)
                {
                    _dbContext.Categories.Add(category);

                }
                else
                {
                    _dbContext.Categories.Update(category);
                }
                _dbContext.SaveChanges();
               
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate");
            }
            return RedirectToAction("List", "Category");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return RedirectToAction("List", "Category");
        }
    }
}
