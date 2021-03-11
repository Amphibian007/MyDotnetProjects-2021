using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
               new Department { DepartmentId=1,Name="Technical"},
               new Department { DepartmentId=2,Name="HR"},
               new Department { DepartmentId=3,Name="Marketing"},
               new Department { DepartmentId=4,Name="Sales"}
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id=1,
                    Name="Dipto",
                    DepartmentId=1,
                    Salary=50000,
                    Experience=3
                },
                new Employee
                {
                    Id = 2,
                    Name = "Pias",
                    DepartmentId = 2,
                    Salary = 5000,
                    Experience = 2
                },
                new Employee
                {
                    Id = 3,
                    Name = "Sujon",
                    DepartmentId = 3,
                    Salary = 15000,
                    Experience = 1
                }
                );
        }
    }
}
