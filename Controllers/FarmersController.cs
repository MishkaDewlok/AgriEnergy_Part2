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
    public class FarmersController : Controller
    {
        private readonly AgriEnergyContext _context;

        public FarmersController(AgriEnergyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> LoginFarmer()
        {

            return RedirectToAction("FarmerLogin", "Home");
        }

        public IActionResult FarmerLogin()
        {
            return View();
        }

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
                    return RedirectToAction("FarmerProducts", "Products");
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

    


        // GET: Farmers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Farmers.ToListAsync());
        }

        // GET: Farmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(m => m.FarmerId == id);
            if (farmer == null)
            {
                return NotFound();
            }

            return View(farmer);
        }

        // GET: Farmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string farmerUserName, string farmerPassword)  //all farmer details are added by the employee
        {
            var dbContext = new AgriEnergyContext();
            Farmer newFarmer = new Farmer();
            newFarmer.FarmerUserName = farmerUserName;
            newFarmer.FarmerPassword = farmerPassword;

            dbContext.Farmers.Add(newFarmer);
            dbContext.SaveChanges();

            return View();

        }

      

        private bool FarmerExists(int id)
        {
            return _context.Farmers.Any(e => e.FarmerId == id);
        }
    }
}
