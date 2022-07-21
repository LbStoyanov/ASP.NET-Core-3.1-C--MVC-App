using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Turns.Models;

namespace Turns.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnsContext _context;
       public EspecialidadController(TurnsContext context)
       {
            _context = context;
       }

        public IActionResult Index()
        {
            return View(_context.Speciality.ToList());
        }
    }
}