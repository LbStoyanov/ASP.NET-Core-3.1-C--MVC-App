using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View(this._context.Specialities.ToList());
        }

        public IActionResult Edit(int? id)
        {   

            if (id == null)
            {
                return NotFound();             
            }

            var speciality = this._context.Specialities.Find(id);

            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("IdSpeciality,Description")] Speciality speciality)
        {
            if (id != speciality.SpecialtyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                this._context.Update(speciality);
                this._context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(speciality);
        }
    }
}