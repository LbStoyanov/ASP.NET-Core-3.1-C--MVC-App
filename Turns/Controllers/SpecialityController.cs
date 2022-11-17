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
    }
}