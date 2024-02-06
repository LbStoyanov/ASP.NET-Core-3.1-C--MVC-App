using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shifts.Models;


namespace Shifts.Controllers
{
    public class SpecialtyController : Controller
    {
        private readonly ShiftsContext _context;
        public SpecialtyController(ShiftsContext context)
        {

            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this._context.Specialties.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var specialty = await this._context.Specialties.FindAsync(id);

            if (specialty == null)
            {
                return NotFound();
            }

            return View(specialty);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("SpecialtyId,Description")] Specialty specialty)
        {
            if (id != specialty.SpecialtyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                this._context.Update(specialty);
                await this._context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialty);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await this._context.Specialties.FirstOrDefaultAsync(x => x.SpecialtyId == id);

            if (specialty == null)
            {
                return NotFound();
            }

            bool isSpecialtyUsed = await _context.DoctorSpecialties.AnyAsync(ds => ds.SpecialtyId == id);

            if (isSpecialtyUsed)
            {
                ViewBag.WarningMessage = "Warning: There are doctors assigned to this speciality. Deleting this specialty may affect related data.";
            }


            return View(specialty);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var specialty = await _context.Specialties.FindAsync(id);

            // Check if the specialty is in use
            var isSpecialityUsed = await _context.DoctorSpecialties.AnyAsync(ds => ds.SpecialtyId == id);
            if (isSpecialityUsed)
            {
                // Handle the case where specialty is in use (e.g., display an error message)
                return View(specialty);
            }

            _context.Specialties.Remove(specialty!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("SpecialtyId,Description")] Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                this._context.Add(specialty);
                await this._context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(specialty);
        }


    }
}