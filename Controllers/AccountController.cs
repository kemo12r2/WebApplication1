using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using WebApplication1.data;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly Dbconnectian _context;

        public AccountController(Dbconnectian context)
        {
            _context = _context;
        }

        // GET: /Account/Signup
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        // POST: /Account/Signup
        [HttpPost]
        public IActionResult Signup(Account account)
        {
            if (ModelState.IsValid)
            {
                if (_context.Accounts.Any(a => a.Email == account.Email))
                {
                    ModelState.AddModelError("Email", "This email is already registered.");
                    return View(account);
                }

                if (_context.Accounts.Any(a => a.Username == account.Username))
                {
                    ModelState.AddModelError("Username", "This username is already taken.");
                    return View(account);
                }

                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);

                _context.Accounts.Add(account);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(account);
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Email and Password are required.");
                return View();
            }

            var account = _context.Accounts.FirstOrDefault(a => a.Email == email);

            if (account == null || !BCrypt.Net.BCrypt.Verify(password, account.Password))
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}