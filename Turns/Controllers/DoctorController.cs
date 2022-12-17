using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turns.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Turns.Controllers
{
    public class DoctorController : Controller
    {
        private readonly TurnsContext _context;

        public DoctorController(TurnsContext context)
        {
            this._context = context;
        }

        // GET: Doctor
        public async Task<IActionResult> Index()
        {
            return View(await this._context.Doctors.ToListAsync());
        }

        // GET: Doctor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await this._context.Doctors
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            ViewData["SpecialitiesList"] = new SelectList(this._context.Specialities, "SpecialityId", "Description");
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorId,FirstName,LastName,Address,PhoneNumber,Email,WorkingHoursFrom,WorkingHoursTo")] Doctor doctor, int SpecialityId)
        {
            if (ModelState.IsValid)
            {
                this._context.Add(doctor);
                await this._context.SaveChangesAsync();

                var doctorSpeciality = new DoctorSpecialities();
                doctorSpeciality.DoctorId = doctor.DoctorId;
                doctorSpeciality.SpecialityId = SpecialityId;
                this._context.Add(doctorSpeciality);

                await this._context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctor/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Inner Join applied
            var doctor = await this._context.Doctors.Where(d => d.DoctorId == id)
            .Include(ds => ds.DoctorSpecialities).FirstOrDefaultAsync();

            if (doctor == null)
            {
                return NotFound();
            }

            ViewData["SpecialitiesList"] = new SelectList(
                this._context.Specialities, "SpecialityId", "Description", doctor.DoctorSpecialities[0].SpecialityId
            );

            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorId,FirstName,LastName,Address,PhoneNumber,Email,WorkingHoursFrom,WorkingHoursTo")] Doctor doctor, int SpecialityId)
        {
            if (id != doctor.DoctorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await this._context.SaveChangesAsync();

                    var doctorSpeciality = await this._context.DoctorSpecialities
                    .FirstOrDefaultAsync(ds => ds.DoctorId == id);

                    this._context.Remove(doctorSpeciality!);
                     await this._context.SaveChangesAsync();

                    doctorSpeciality!.SpecialityId = SpecialityId;

                    this._context.Add(doctorSpeciality);

                    await this._context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.DoctorId))
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
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctor!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.DoctorId == id);
        }
    }
}
