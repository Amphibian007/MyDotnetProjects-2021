using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Areas.Admin.Controllers
{
   [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ShopContext _dbContext;
        private List<Category> categories;
        public ProductController(ShopContext dbContext)
        {
            _dbContext = dbContext;
            categories = _dbContext.Categories.OrderBy(m => m.Name).ToList();
        }
        public IActionResult Index()
        {
            return RedirectToAction("List","Product");
        }
        [Route("[area]/[controller]s/{id?}")]
        public IActionResult List(string id="All")
        {
            List<Product> products;
            if (id == "All")
            {
                products = _dbContext.Products.OrderBy(p => p.ProductID).ToList();
            }
            else
            {
                products = _dbContext.Products.Where(p => p.Category.Name == id).ToList();
            }
            var model = new ProductListViewModel()
            {
                Categories = categories,
                Products = products,
                SelectedCategory = id
            };
            //ViewBag.AllCategories = categories;
            //ViewBag.SelectedCategoryName = id;
            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var product = new Product();
            product.Category = _dbContext.Categories.Find(1);
            ViewBag.Action = "Add";
            ViewBag.Categories = categories;
            return View("AddUpdate",product);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _dbContext.Products.Include(p=>p.Category).FirstOrDefault(p=>p.ProductID==id);
            ViewBag.Action = "Update";
            ViewBag.Categories = categories;
            return View("AddUpdate", product);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                var userMessage = "";
                if (product.ProductID == 0)
                {
                    _dbContext.Products.Add(product);
                    userMessage = "You just added a product " + product.Name;
                }
                else
                {
                    _dbContext.Products.Update(product);
                    userMessage = "You just updated a product " + product.Name;
                }
                _dbContext.SaveChanges();
                TempData["UserMessage"] = userMessage;
                return RedirectToAction("List", "Product");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", product);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p=>p.ProductID==id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return RedirectToAction("List", "Product");
        }
    }
}
