using Microsoft.AspNetCore.Mvc;

namespace Turns.Controllers
{
    public class EspecialidadController : Controller
    {
       public EspecialidadController()
       {

       }

        public IActionResult Index()
        {
            return View();
        }
    }
}