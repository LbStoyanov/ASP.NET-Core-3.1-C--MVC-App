using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shifts.Models;

namespace Shifts.Controllers
{
    public class ShiftController : Controller
    {
        private readonly ShiftsContext _context;

        private IConfiguration _configuration;

        public ShiftController(ShiftsContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["DoctorId"] =
            new SelectList((from doctor in _context.Doctors.ToList() select new { DoctorId = doctor.DoctorId, FullName = doctor.FirstName + " " + doctor.LastName }), "DoctorId", "FullName");

            ViewData["PatientId"] =
            new SelectList((from patient in _context.Patients.ToList() select new { PatientId = patient.PatientId, FullName = patient.FirstName + " " + patient.LastName }), "PatientId", "FullName");

            return View();
        }

        public JsonResult GetShifts(int doctorId)
        {

            var shifts = _context.Shifts.Where(t => t.DoctorId == doctorId)
            .Select(t => new
            {
                t.ShiftId,
                t.DoctorId,
                t.PatientId,
                t.DateTimeStart,
                t.DateTimeEnd,
                patient = t.Patient.FirstName + ", " + t.Patient.LastName
            })
            .ToList();

            return Json(shifts);
        }

        [HttpPost]
        public JsonResult SaveShift(Shift shift)
        {
            var ok = false;

            try
            {
                _context.Shifts.Add(shift);
                _context.SaveChangesAsync();
                ok = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} Exception found!");
            }

            var jsonResult = new { ok = ok };

            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult DeleteShift(int shiftId)
        {
            var ok = false;

            try
            {
                var shiftForDelete = _context.Shifts.Where(t => t.ShiftId == shiftId).FirstOrDefault();
                if (shiftForDelete != null)
                {
                    _context.Shifts.Remove(shiftForDelete);
                    _context.SaveChangesAsync();
                    ok = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} Exception found!");
            }

            var jsonResult = new { ok = ok };

            return Json(jsonResult);
        }
    }
}