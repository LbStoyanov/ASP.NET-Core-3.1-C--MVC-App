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
            return View();
        }
    }
}