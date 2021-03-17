using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ToDoContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(string id)
        {
            var model = new ToDoViewModel();
            model.Filters = new Filters(id);
            model.Categories = _dbContext.Categories.ToList();
            model.Statuses = _dbContext.Statuses.ToList();
            model.DueFilters = Filters.DueFilterValues;
            IQueryable<ToDo> query = _dbContext.ToDos.Include(c => c.Category).Include(s => s.Status);
            if (model.Filters.HasCategory)
                query = query.Where(t => t.CategoryId == model.Filters.CategoryId);
            if (model.Filters.HasStatus)
                query = query.Where(t => t.StatusId == model.Filters.StatusId);
            if(model.Filters.HasDue)
            {
                var today = DateTime.Today;
                if (model.Filters.IsPast)
                    query = query.Where(t => t.DueDate < today);
                else if (model.Filters.IsToday)
                    query = query.Where(t => t.DueDate == today);
                else if(model.Filters.IsFuture)
                    query = query.Where(t => t.DueDate > today);
            }
            var tasks = query.OrderBy(t => t.DueDate).ToList();
            model.Tasks = tasks;
            return View(model);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ToDoViewModel();
            model.Categories = _dbContext.Categories.ToList();
            model.Statuses = _dbContext.Statuses.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(ToDoViewModel model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.ToDos.Add(model.CurrentTask);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.Categories = _dbContext.Categories.ToList();
                model.Statuses = _dbContext.Statuses.ToList();
                return View(model);
            }
           
        }
        [HttpPost]
        public IActionResult EditDelete([FromRoute] string id, ToDo selected)
        {
            if (selected.StatusId == null)
            {
                _dbContext.ToDos.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = _dbContext.ToDos.Find(selected.StatusId);
                selected.StatusId = newStatusId;
                _dbContext.ToDos.Update(selected);
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home", new { Id = id });
        }
        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", "Home", new { Id = id });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
