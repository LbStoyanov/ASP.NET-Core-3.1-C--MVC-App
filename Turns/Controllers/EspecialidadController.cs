using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Turns.Models;

namespace Turns.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnsContext context;
       public EspecialidadController(TurnsContext context)
       {
            this.context = context;
       }

        public IActionResult Index()
        {
            return View(this.context.Speciality.ToList());
        }
    }
}