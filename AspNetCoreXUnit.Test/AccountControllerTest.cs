using AspNetCoreXUnit.Controllers;
using AspNetCoreXUnit.Data;
using AspNetCoreXUnit.Models;
using AspNetCoreXUnit.Services;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AspNetCoreXUnit.Test
{
    class AccountControllerTest
    {
        object _userManager;
        object _signInManager;
        object _emailSender;
        object _smsSender;
        private readonly ApplicationDbContext _dbContext;

        public AccountControllerTest()
        {
            _userManager = new Mock<UserManager<ApplicationUser>>();
            _signInManager = new Mock<SignInManager<ApplicationUser>>();
            _emailSender = new Mock<IEmailSender>();
            _smsSender = new Mock<ISmsSender>();

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseInMemoryDatabase();
            _dbContext = new ApplicationDbContext(optionBuilder.Options);
            //loggerFactory = new Mock<ILoggerFactory>();
            //_logger = loggerFactory.CreateLogger<AccountController>();
        }
        [Fact]
        public void Register_ValidInput_ReturnTrue()
        {

        }
    }
}
