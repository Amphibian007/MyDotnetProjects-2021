using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingPractise.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult List(string product,int page)
        {
            var message = $"Product controller , list action method ,{product} and {page} ";
            return Content(message);
        }
    }
}
