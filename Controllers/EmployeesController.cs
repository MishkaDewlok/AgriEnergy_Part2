using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriEnergy.Models;

namespace AgriEnergy.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AgriEnergyContext _context;

        public EmployeesController(AgriEnergyContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> LoginEmp()
        {

            return RedirectToAction("EmployeeLogin", "Home");
        }

        public IActionResult EmployeeLogin()
        {
            return View();
        }
        //------------CODE ATTRIBUTION-----------------------------------------------------------------------
        //for login:
        //scaffolded using entity framework, adapted from:
        //author:Martin Petrovaj
        //URL:https://www.ictdemy.com/csharp/asp-net-core/basics/scaffolding-and-entity-framework-in-aspnet-core-mvc

        //author:BautaBear, Manoj Roy
        //URL:https://stackoverflow.com/questions/41705235/entity-framework-core-creating-model-from-existing-database?rq=1

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
                    return RedirectToAction("Index", "Farmers");
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

            ViewBag.Message = "User Details Saved";
            return RedirectToAction("EmployeeLogin", "Employees");

        }

   

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }


        public IActionResult AddFarmer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFarmer(string farmerUserName, string farmerPassword)
        {


            return View();

        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeUserName,EmployeePassword")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

       

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
