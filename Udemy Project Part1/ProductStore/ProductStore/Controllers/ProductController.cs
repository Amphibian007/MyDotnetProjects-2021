using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopContext _dbContext;
       

        public ProductController(ShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }
        [Route("[controller]s/{id?}")]
        public IActionResult List(string id="All")
        {
            var categories = _dbContext.Categories.OrderBy(c => c.CategoryID).ToList();
            List<Product> products;
            if (id == "All")
            {
                products = _dbContext.Products.OrderBy(p => p.ProductID).ToList();
            }
            else if (id == "Specials")
            {
                products = _dbContext.Products.Where(p => p.Price < 5.0M).OrderBy(p => p.ProductID).ToList();
            }
            else
            {
                products = _dbContext.Products.Where(p => p.Category.Name == id).OrderBy(p => p.ProductID).ToList();
            }
            var model = new ProductListViewModel()
            {
                Categories = categories,
                Products = products,
                SelectedCategory = id
            };
            //ViewBag.SelectedCategoryName = id;
            //ViewBag.AllCategories = categories;
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var categories = _dbContext.Categories.OrderBy(c => c.CategoryID).ToList();
            var product = _dbContext.Products.Find(id);
            var categoryName = "";
            foreach(var category in categories)
            {
                if (category.CategoryID == product.CategoryID)
                    categoryName = category.Name;
            }
            ViewBag.CategoryName = categoryName;
           
            string imageFileName = product.Code + "-m.jpg";
            ViewBag.ImageFileName = imageFileName;
            return View(product);
        }
    }
}
