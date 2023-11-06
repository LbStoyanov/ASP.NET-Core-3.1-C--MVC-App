using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Turns.Models;

namespace Turns.Controllers
{
    public class TurnController : Controller
    {
        private readonly TurnsContext _context;

        private IConfiguration _configuration;

        public TurnController(TurnsContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["DoctorId"] = 
            new SelectList((from doctor in _context.Doctors.ToList() select new { DoctorId = doctor.DoctorId, FullName = doctor.FirstName + " " + doctor.LastName}),"DoctorId", "FullName");
            
            ViewData["PatientId"] = 
            new SelectList((from patient in _context.Patients.ToList() select new { PatientId = patient.PatientId, FullName = patient.FirstName + " " + patient.LastName}),"PatientId", "FullName");

            return View();
        }

        public JsonResult GetTurns (int doctorId)
        {
        
            var turns = _context.Turns.Where(t => t.DoctorId == doctorId)
            .Select(t => new {
                t.TurnId,
                t.DoctorId,
                t.PatientId,
                t.DateTimeStart,
                t.DateTimeEnd,
                patient = t.Patient.FirstName + ", " + t.Patient.LastName
            })
            .ToList();

            return Json(turns);
        }

        [HttpPost]
        public JsonResult SaveTurn(Turn turn)
        {
            var ok =  false;

            try
            {
                _context.Turns.Add(turn);
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
        public JsonResult DeleteTurn (int turnId)
        {
            var ok =  false;

            try
            {
                var turnForDelete = _context.Turns.Where(t => t.TurnId == turnId).FirstOrDefault();
                if (turnForDelete != null)
                {
                    _context.Turns.Remove(turnForDelete);
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