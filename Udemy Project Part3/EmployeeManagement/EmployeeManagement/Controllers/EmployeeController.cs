using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeController(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Create()
        {
            ViewBag.Action = "Create";
            ViewBag.Departments = _dbContext.Departments.OrderBy(m => m.Name).ToList();
            return View("Edit",new Employee());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var employee = _dbContext.Employees.Find(id);
            ViewBag.Departments = _dbContext.Departments.OrderBy(m => m.Name).ToList();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Id == 0)
                {
                    _dbContext.Employees.Add(employee);
                }
                else
                {
                    _dbContext.Employees.Update(employee);
                }
                _dbContext.SaveChanges();            
            }
            else
            {
                ViewBag.Departments = _dbContext.Departments.OrderBy(m => m.Name).ToList();
                ViewBag.Action = employee.Id == 0 ? "Create" : "Edit";
                return View(employee);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
