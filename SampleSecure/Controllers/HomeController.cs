using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SampleSecure.Models;
using Microsoft.EntityFrameworkCore;
using SampleSecure.Data; 
using BCrypt.Net; 

namespace SampleSecure.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Periksa apakah pengguna sudah login
            var username = HttpContext.Session.GetString("User");
            if (username == null)
            {
                // Jika belum login, arahkan ke halaman Login
                return RedirectToAction("Login");
            }

            // Jika sudah login, tampilkan halaman utama
            ViewBag.username = username;
            return View();
        }

        public IActionResult Students()
        {
            // Cek apakah pengguna sudah login
            var username = HttpContext.Session.GetString("User");
            if (username == null)
            {
                // Jika belum login, arahkan ke halaman Login
                return RedirectToAction("Login");
            }

            var students = _context.Students.ToList();
            return View(students);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Menghapus sesi pengguna
            HttpContext.Session.Remove("User");

            // Mengarahkan pengguna ke halaman Login
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == model.Username);
            if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                HttpContext.Session.SetString("User", model.Username);
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Username atau password salah.";
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Username = model.Username,
                    Password = BCrypt.Net.BCrypt.HashPassword(model.Password)
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About Page";
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
