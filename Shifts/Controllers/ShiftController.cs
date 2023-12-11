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
            this._context = context;
            this._configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["DoctorId"] =
            new SelectList(from doctor in this._context.Doctors.ToList() select new { doctor.DoctorId, FullName = doctor.FirstName + " " + doctor.LastName }, "DoctorId", "FullName");

            ViewData["PatientId"] =
            new SelectList(from patient in this._context.Patients.ToList() select new { patient.PatientId, FullName = patient.FirstName + " " + patient.LastName }, "PatientId", "FullName");

            return View();
        }

        public JsonResult GetShifts(int doctorId)
        {

            var shifts = this._context.Shifts.Where(sh => sh.DoctorId == doctorId)
            .Select(sh => new
            {
                sh.ShiftId,
                sh.DoctorId,
                sh.PatientId,
                sh.DateTimeStart,
                sh.DateTimeEnd,
                patient = sh.Patient.FirstName + ", " + sh.Patient.LastName
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
                this._context.Shifts.Add(shift);
                this._context.SaveChangesAsync();
                ok = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex} Exception found!");
            }

            var jsonResult = new { ok };

            return Json(jsonResult);
        }

        [HttpPost]
        public JsonResult DeleteShift(int shiftId)
        {
            var ok = false;

            try
            {
                var shiftForDelete = this._context.Shifts.Where(t => t.ShiftId == shiftId).FirstOrDefault();
                if (shiftForDelete != null)
                {
                    this._context.Shifts.Remove(shiftForDelete);
                    this._context.SaveChangesAsync();
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