using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingPractise.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("This is awesome");
        }
        [Route("About")]
        public IActionResult About()
        {
            return Content("This is about");
        }
        public IActionResult Display(int id)
        {
            if (id == 0)
            {
                return Content("No id provided");
            }
            else
            {
                return Content($"Id is {id}");
            }
        }
        [Route("{action}/{start}/{end?}/{message?}")]
        public IActionResult CountDown(int start,int end=0,string message="")
        {
            var output = "Counting down\n";
            for(int i = start; i>end; i--)
            {
                output = $"{output} {i}\n";
            }
            output += message;
            return Content(output);
        }
    }
}
