using AgriEnergy.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgriEnergy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult EmployeeLogin()
        {
            return View();

        }
        //employees will be able to login in to their accounts to view the farmers products and add new farmers
        [HttpPost]
        public IActionResult EmployeeLogin(string employeeUserName, string employeePassword)
        {
            var dbContext = new AgriEnergyContext();
            Employee loginEmployee = dbContext.Employees.FirstOrDefault(s => s.EmployeeUserName == employeeUserName);
            if (loginEmployee != null)
            {
                if (loginEmployee.EmployeePassword == employeePassword)
                {
                    HttpContext.Session.SetInt32("ID", loginEmployee.EmployeeId);
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        public IActionResult EmployeeSignUp()
        {
            return View();
        }
        //if the employee is new and does not have an account,
        //they will click signup and create an account
        //the user will have to enter the details to that it can then get stored into the database
        //then it will go into the login page
        [HttpPost]
        public IActionResult EmployeeSignUp(string employeeUserName, string employeePassword)
        {
            var dbContext = new AgriEnergyContext();
            Employee newEmployee = new Employee();
            newEmployee.EmployeeUserName = employeeUserName;
            newEmployee.EmployeePassword = employeePassword;

            dbContext.Employees.Add(newEmployee);
            dbContext.SaveChanges();

            return RedirectToAction("EmployeeLogin", "Employees");

        }

        public IActionResult FarmerLogin()
        {
            return View();
        }
        /*
        //farmers will be able to login in to their accounts to view their stock
        [HttpPost]
        public IActionResult FarmerLogin(string farmerUserName, string farmerPassword)
        {
            var dbContext = new AgriEnergyContext();
            Farmer loginFarmer = dbContext.Farmers.FirstOrDefault(s => s.FarmerUserName == farmerUserName);
            if (loginFarmer != null)
            {
                if (loginFarmer.FarmerPassword == farmerPassword)
                {
                    HttpContext.Session.SetInt32("ID", loginFarmer.FarmerId);
                    return RedirectToAction("Filter", "Products");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }

        }

        */

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
