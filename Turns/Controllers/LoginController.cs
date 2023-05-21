using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Turns.Models;

namespace Turns.Controllers
{
    public class LoginController : Controller
    {
        private readonly TurnsContext _context;

        public LoginController(TurnsContext context)
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

                var userLogin = _context.Logins.Where(l => l.Username  == login.Username && l.Password == encryptedPassword)
                .FirstOrDefault();
                
                if(userLogin != null)
                {
                    HttpContext.Session.SetString("username", userLogin.Username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["errorLogin"] = "The entered credentials are invalid!";
                    return View("Index");
                }

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

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}