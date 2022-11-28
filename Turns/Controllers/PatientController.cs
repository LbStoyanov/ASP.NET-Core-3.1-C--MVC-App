using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turns.Models;

namespace Turns.Controllers
{
    public class PatientController : Controller
    {
        private readonly TurnsContext _context;

        public PatientController(TurnsContext context)
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

            var patient = await this._context.Patients.FirstOrDefaultAsync(p=>p.PatientId == id);

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

    }
}