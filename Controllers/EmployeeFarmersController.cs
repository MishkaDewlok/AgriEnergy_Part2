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
    public class EmployeeFarmersController : Controller
    {
        private readonly AgriEnergyContext _context;

        public EmployeeFarmersController(AgriEnergyContext context)
        {
            _context = context;
        }

        // GET: EmployeeFarmers
        public async Task<IActionResult> Index()
        {
            var agriEnergyContext = _context.EmployeeFarmers.Include(e => e.Employee).Include(e => e.Farmer);
            return View(await agriEnergyContext.ToListAsync());
        }

        // GET: EmployeeFarmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFarmer = await _context.EmployeeFarmers
                .Include(e => e.Employee)
                .Include(e => e.Farmer)
                .FirstOrDefaultAsync(m => m.Farmers == id);
            if (employeeFarmer == null)
            {
                return NotFound();
            }

            return View(employeeFarmer);
        }

        // GET: EmployeeFarmers/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FarmerId", "FarmerId");
            return View();
        }

        // POST: EmployeeFarmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Farmers,EmployeeId,FarmerId")] EmployeeFarmer employeeFarmer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeFarmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeeFarmer.EmployeeId);
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FarmerId", "FarmerId", employeeFarmer.FarmerId);
            return View(employeeFarmer);
        }

        // GET: EmployeeFarmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFarmer = await _context.EmployeeFarmers.FindAsync(id);
            if (employeeFarmer == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeeFarmer.EmployeeId);
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FarmerId", "FarmerId", employeeFarmer.FarmerId);
            return View(employeeFarmer);
        }

        // POST: EmployeeFarmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Farmers,EmployeeId,FarmerId")] EmployeeFarmer employeeFarmer)
        {
            if (id != employeeFarmer.Farmers)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeFarmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeFarmerExists(employeeFarmer.Farmers))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeeFarmer.EmployeeId);
            ViewData["FarmerId"] = new SelectList(_context.Farmers, "FarmerId", "FarmerId", employeeFarmer.FarmerId);
            return View(employeeFarmer);
        }

        // GET: EmployeeFarmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeFarmer = await _context.EmployeeFarmers
                .Include(e => e.Employee)
                .Include(e => e.Farmer)
                .FirstOrDefaultAsync(m => m.Farmers == id);
            if (employeeFarmer == null)
            {
                return NotFound();
            }

            return View(employeeFarmer);
        }

        // POST: EmployeeFarmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeFarmer = await _context.EmployeeFarmers.FindAsync(id);
            if (employeeFarmer != null)
            {
                _context.EmployeeFarmers.Remove(employeeFarmer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeFarmerExists(int id)
        {
            return _context.EmployeeFarmers.Any(e => e.Farmers == id);
        }
    }
}
