using Microsoft.AspNetCore.Mvc;

namespace HeaLEOO.Controllers
{
    public class UserManagmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
