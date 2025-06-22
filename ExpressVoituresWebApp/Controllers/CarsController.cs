using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpressVoituresWebApp.Data;

namespace ExpressVoituresWebApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cars
                .Include(c => c.Model.Manufacturer)
                .Include(c => c.Model.Finition);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Model.Manufacturer)
                .Include(c => c.Model.Finition)
                .FirstOrDefaultAsync(m => m.Vin == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            PopulateSelectLists();
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Vin,Model,PurchasePrice,PurchaseDate,ListingDate,ResellPrice,ResellDate,Description,ImageUrl")] Car car,
            IFormFile? ImageFile)
        {
            car.Model = GetContextCarModelInstance(car.Model);
            if (car.Model == null)
            {
                ModelState.AddModelError("Model", "Ce modèle n'existe pas");
            }
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }
                    car.ImageUrl = "/images/" + uniqueFileName;
                }

                _context.Add(car);
                await _context.SaveChangesAsync();
                return View("CreateSuccess");
            }
            PopulateSelectLists();
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Model.Finition)
                .FirstOrDefaultAsync(c => c.Vin == id);

            if (car == null)
            {
                return NotFound();
            }
            PopulateSelectLists();
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Vin,Model,PurchasePrice,PurchaseDate,ListingDate,ResellPrice,ResellDate,Description,ImageUrl")] Car car,
            IFormFile? ImageFile)
        {
            if (id != car.Vin)
            {
                return NotFound();
            }

            car.Model = GetContextCarModelInstance(car.Model);
            if (car.Model == null)
            {
                ModelState.AddModelError("Model", "Ce modèle n'existe pas");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + ImageFile.FileName;
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(fileStream);
                        }
                        car.ImageUrl = "/images/" + uniqueFileName;
                    }

                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Vin))
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
            PopulateSelectLists();
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Model.Manufacturer)
                .Include(c => c.Model.Finition)
                .FirstOrDefaultAsync(m => m.Vin == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var car = await _context.Cars
                .Include(c => c.Model.Manufacturer)
                .Include(c => c.Model.Finition)
                .FirstOrDefaultAsync(m => m.Vin == id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return View("DeleteSuccess", car);
        }

        private bool CarExists(long id)
        {
            return _context.Cars.Any(e => e.Vin == id);
        }

        private CarModel? GetContextCarModelInstance(CarModel model)
        {
            return _context.CarModels
                .Include(cm => cm.Manufacturer)
                .FirstOrDefault(cm => cm.ManufacturerId == model.ManufacturerId
                          && cm.Name == model.Name
                          && cm.Finition == model.Finition
                          && cm.Year == model.Year);
        }

        private void PopulateSelectLists()
        {
            ViewData["Manufacturers"] = new SelectList(
                _context.Manufacturers.Where(m => m.Models.Any()),
                "Id", "Name");

            ViewData["CarModelNames"] = new SelectList(_context.CarModels
                .Select(cm => new {cm.Name})
                .Distinct(),
                "Name", "Name");

            ViewData["CarModelFinitions"] = new SelectList(_context.ModelFinitions);
        }
    }
}
