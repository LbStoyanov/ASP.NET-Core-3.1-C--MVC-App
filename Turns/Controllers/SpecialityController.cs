using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turns.Models;

namespace Turns.Controllers
{
    public class SpecialityController : Controller
    {
        private readonly TurnsContext _context;
        public SpecialityController(TurnsContext context)
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


            return View(speciality);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var speciality = await this._context.Specialities.FindAsync(id);

            this._context.Specialities.Remove(speciality!);
            await this._context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}