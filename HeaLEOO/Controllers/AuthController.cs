using HeaLEOO.ALLServices;
using HeaLEOO.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HeaLEOO.Controllers
{
    public class AuthController : Controller
    {
        private readonly IServiceAuth _serviceAuth;

        public AuthController(IServiceAuth serviceAuth)
        {
            _serviceAuth = serviceAuth;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
                return View(register);

            var result = await _serviceAuth.RegisterAsync(register);
            if (result)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Email already exists or registration failed.");
            return View(register);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var result = await _serviceAuth.LoginAsync(login);
            if (result)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Invalid Email or Password.");
            return View(login);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _serviceAuth.Logout();
            return RedirectToAction("Login", "Auth");
        }
    }
}
