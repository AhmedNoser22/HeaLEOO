using Microsoft.AspNetCore.Mvc;

namespace HeaLEOO.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
