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
    public class ProductsController : Controller
    {
        private readonly AgriEnergyContext _context;

        public ProductsController(AgriEnergyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Filter(int? farmerId, string category, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Products.AsQueryable();

            if (farmerId.HasValue)
            {
                query = query.Where(p => p.FarmerId == farmerId.Value);
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.ProductCategory == category);
            }

            if (startDate.HasValue)
            {
                query = query.Where(p => p.ProductionDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(p => p.ProductionDate <= endDate.Value);
            }

            var result = await query.ToListAsync();
            return View(result);
        }

        //Displays products according to farmers logged in
        public async Task<IActionResult> FarmerProducts()
        {
            var query = _context.Products.AsQueryable();

            var farmerId = (int)HttpContext.Session.GetInt32("ID");
    
            
            query = query.Where(p => p.FarmerId == farmerId);
            

            

            var result = await query.ToListAsync();
            return View(result);
        }


            // GET: Products
            public async Task<IActionResult> Index(int farmerId, int employeeId)    //gets input from farmer for the product
        {

            employeeId = (int)HttpContext.Session.GetInt32("ID");
            if (employeeId != 0)
            {

                var Employee = _context.Products;


                return View(await Employee.ToListAsync());

            }

            else
            {


                farmerId = (int)HttpContext.Session.GetInt32("ID");
                var Farmer = _context.Products.Where(s => s.FarmerId == farmerId); farmerId = (int)HttpContext.Session.GetInt32("ID");
                return View(await Farmer.ToListAsync());
            }


    }




        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Farmer)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FarmerId", "FarmerId");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductPrice,ProductQuantity,ProductCategory,ProductionDate,FarmerId")] Product product)
        {
            product.FarmerId = (int)HttpContext.Session.GetInt32("ID");

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FarmerId", "FarmerPassword", product.FarmerId);
            return View(product);
        }



        public async Task<IActionResult> ViewFarmerProducts(int? UserId, string category)
        {
            if (UserId == null)
            {
                return NotFound();
            }

            var productsQuery = _context.Products
                .Include(p => p.FarmerId)
                .Where(p => p.FarmerId == UserId);

            // Apply category filter if specified
            
                var searchOutput = productsQuery.Where(p => p.ProductCategory.Contains(category));
           

   
            var products = await productsQuery.ToListAsync();

            if (products == null || !products.Any())
            {
                return View("~/Views/Home/Privacy.cshtml");
            }

            ViewBag.FarmerId = UserId; // Ensure UserId is passed back to the view for filtering
            return View(searchOutput);
        }



        // GET: Products/Edit/5

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
