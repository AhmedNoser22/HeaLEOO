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

    }
}
