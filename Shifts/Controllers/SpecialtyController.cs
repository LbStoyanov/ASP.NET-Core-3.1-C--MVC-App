using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shifts.Models;

namespace Shifts.Controllers
{
    public class SpecialityController : Controller
    {
        private readonly ShiftsContext _context;
        public SpecialityController(ShiftsContext context)
        {

            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this._context.Specialities.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var speciality = await this._context.Specialities.FindAsync(id);

            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("SpecialityId,Description")] Speciality speciality)
        {
            if (id != speciality.SpecialityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                this._context.Update(speciality);
                await this._context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(speciality);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciality = await this._context.Specialities.FirstOrDefaultAsync(x => x.SpecialityId == id);

            if (speciality == null)
            {
                return NotFound();
            }

            bool isSpecialityUsed = await _context.DoctorSpecialities.AnyAsync(ds => ds.SpecialityId == id);

            if (isSpecialityUsed)
            {
                ViewBag.WarningMessage = "Warning: There are doctors assigned to this speciality. Deleting this speciality may affect related data.";
            }


            return View(speciality);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var speciality = await _context.Specialities.FindAsync(id);

            // Check if the speciality is in use
            var isSpecialityUsed = await _context.DoctorSpecialities.AnyAsync(ds => ds.SpecialityId == id);
            if (isSpecialityUsed)
            {
                // Handle the case where speciality is in use (e.g., display an error message)
                return View(speciality);
            }

            _context.Specialities.Remove(speciality!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("SpecialityId,Description")] Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                this._context.Add(speciality);
                await this._context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(speciality);
        }


    }
}