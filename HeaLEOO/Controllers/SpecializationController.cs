using Microsoft.AspNetCore.Mvc;

namespace HeaLEOO.Controllers
{
    public class SpecializationController : Controller
    {
        private readonly IserviceSpecializations _serviceSpecializations;

        public SpecializationController(IserviceSpecializations serviceSpecializations)
        {
            _serviceSpecializations = serviceSpecializations;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
