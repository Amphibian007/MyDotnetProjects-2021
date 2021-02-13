using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableStore.Models;

namespace TableStore.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            var allTables = TableRepository.GetAll();
            return View(allTables);
        }
        public IActionResult GetById(string linkName)
        {
            var singleTable = TableRepository.GetSingleItem(linkName);
            return View(singleTable);
        }
    }
}
