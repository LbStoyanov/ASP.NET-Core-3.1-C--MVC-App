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

        public IActionResult Edit(int id)
        {   
            var speciality = this._context.Specialities.Find(id);

            return View(speciality);
        }
    }
}