using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shifts.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Shifts.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ShiftsContext _context;

        public DoctorController(ShiftsContext context)
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
                .Where(m => m.DoctorId == id).Include(ds => ds.DoctorSpecialities)
                .ThenInclude(s => s.Speciality).FirstOrDefaultAsync();

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorId,FirstName,LastName,Address,PhoneNumber,Email,WorkingHoursFrom,WorkingHoursTo")] Doctor doctor, int SpecialityId)
        {
            if (ModelState.IsValid)
            {
                this._context.Doctors.Add(doctor);
                await this._context.SaveChangesAsync();
                //IF SPECIALTY ID IS NULL FIRST MUST BE CREATED A SPECIALITY FOR THIS DOCTOR!!!
                

                var doctorSpeciality = new DoctorSpecialities
                {
                    DoctorId = doctor.DoctorId,
                    SpecialityId = SpecialityId
                };
                this._context.DoctorSpecialities.Add(doctorSpeciality);

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
        [HttpGet]
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
            var doctorSpeciality = await this._context.DoctorSpecialities
            .FirstOrDefaultAsync(ds => ds.DoctorId == id);

            this._context.DoctorSpecialities.Remove(doctorSpeciality!);
            await _context.SaveChangesAsync();

            var doctor = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctor!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.DoctorId == id);
        }

        public string SetWorkingTimeFrom(int doctorId)
        {

            //TODO: Validate the case if the doctorId is null!!!!!
            var WorkingHoursFrom = _context.Doctors.Where(m => m.DoctorId == doctorId).FirstOrDefault()!.WorkingHoursFrom;

            return WorkingHoursFrom.Hour + ":" + WorkingHoursFrom.Minute;
        }

        public string SetWorkingTimeTo(int doctorId)
        {
            var WorkingHoursTo = _context.Doctors.Where(m => m.DoctorId == doctorId).FirstOrDefault()!.WorkingHoursTo;

            return WorkingHoursTo.Hour + ":" + WorkingHoursTo.Minute;
        }
    }
}
