using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarInfo.Models;
using CarInfo.Database;

namespace CarInfo.WebApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationContext _context;

        public CarsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Cars
        public IActionResult Index()
        {
            CarIndexVM viewModel = new CarIndexVM
            {
                Cars = _context.Cars.ToList(),
                Colors = _context.Cars.Select(i => i.Color).ToList()
            };
            if (_context.Cars.Count() is not 0)
            {
                viewModel.StartPrice = _context.Cars.Min(i => i.Price).ToString();
                viewModel.EndPrice = _context.Cars.Max(i => i.Price).ToString();
            }
            return _context.Cars != null ?
                        View(viewModel) :
                        Problem("Hozircha hech qanday malumot yo'q");
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.CarId == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FirstOrDefaultAsync(m => m.CarId == id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cars == null)
            {
                return Problem("Bunday model tizimda yo'q");
            }
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return (_context.Cars?.Any(e => e.CarId == id)).GetValueOrDefault();
        }

        public IActionResult SearchCar(string? colors, string? startPrice, string? endPrice)
        {
            List<Car> cars = new List<Car>();

            List<string> colorList = new List<string>();

            decimal startPriceDecimal = decimal.MinValue;
            bool checkStart = decimal.TryParse(startPrice, out startPriceDecimal);

            decimal EndPriceDecimal = decimal.MaxValue;
            bool checkEnd = decimal.TryParse(startPrice, out EndPriceDecimal);

            if (colors is not null)
            {
                colorList = colors.Split(",").ToList();
            }

            return RedirectToAction(nameof(Index), cars);
        }
    }
}
