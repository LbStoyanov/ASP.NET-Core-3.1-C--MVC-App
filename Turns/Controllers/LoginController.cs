using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Turns.Models;

namespace Turns.Controllers
{
    public class LogginController : Controller
    {
        private readonly TurnsContext _context;

        public LogginController(TurnsContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(Login login)
        {
            if(ModelState.IsValid)
            {
                string encryptedPassword = Encrypt(login.Password);
            }

            return View("Index");
        }

        public string Encrypt(string password)
        {
           using(SHA256 sha256Hash = SHA256.Create())
           {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
           }
        }
    }
}