using AspNetCoreXUnit.Controllers;
using AspNetCoreXUnit.Data;
using AspNetCoreXUnit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCoreXUnit.Test
{
    public class StudentControllerTest
    {
        private readonly ApplicationDbContext _dbContext;
        public IConfigurationRoot Configuration { get; }
        public StudentControllerTest() {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionBuilder.Options);
            
            //var optionBuilder2 = new DbContextOptionsBuilder<ApplicationDbContext>();
            //optionBuilder2.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //var secondContext = new ApplicationDbContext((optionBuilder2.Options));
            //Add Test Data
            _dbContext.Student.Add(new Student() { FirstName = "Rajeev", LastName = "Soni" });
            _dbContext.Student.Add(new Student() { FirstName = "Suryaveer", LastName = "Singh" });
            _dbContext.SaveChanges();
        }
        [Fact]
        public void StudentController_Index_ReturnsAllStudent()
        {
            var controller = new StudentsController(_dbContext);
            var result = (controller.Index() as Task<IActionResult>).Result as ViewResult ;

            var viewModel = (result.ViewData.Model as IEnumerable<Student>).ToList();
            Assert.Equal(1, viewModel.Count(s => s.FirstName == "Rajeev"));
            Assert.Equal(2, viewModel.Count);
        }
        [Fact]
        public void StudentController_Index_ReturnsAllStudent_Fail()
        {
            var controller = new StudentsController(_dbContext);
            var result = (controller.Index() as Task<IActionResult>).Result as ViewResult;

            var viewModel = (result.ViewData.Model as IEnumerable<Student>).ToList();
            Assert.Equal(1, viewModel.Count(s => s.FirstName == "Rajeev"));
            Assert.Equal(3, viewModel.Count);
        }
    }
}
