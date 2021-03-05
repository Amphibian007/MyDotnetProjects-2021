using Microsoft.AspNetCore.Mvc;
using ProductStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult List()
        {
            var products = ProductRepository.GetAllProducts();
            return View(products);
        }
        public IActionResult Details(string slug)
        {
            var product = ProductRepository.GetSingleProduct(slug);
            
            return View(product);
        }
    }
}
