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
    }
}