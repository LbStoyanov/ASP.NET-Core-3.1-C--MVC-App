using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shifts.Models;

namespace Shifts.Controllers
{
    public class PatientController : Controller
    {
        private readonly ShiftsContext _context;

        public PatientController(ShiftsContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this._context.Patients.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await this._context.Patients.FirstOrDefaultAsync(p => p.PatientId == id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,FirstName,LastName,Direction,PhoneNumber,Email")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                this._context.Add(patient);
                await this._context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(patient);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await this._context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientId,FirstName,LastName,Direction,PhoneNumber,Email")] Patient patient)
        {
            if (id != patient.PatientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                this._context.Update(patient);
                await this._context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(patient);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await this._context.Patients.FirstOrDefaultAsync(x => x.PatientId == id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await this._context.Patients.FindAsync(id);


            if (patient == null)
            {
                return NotFound();
            }

            this._context.Patients.Remove(patient);
            await this._context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

    }
}