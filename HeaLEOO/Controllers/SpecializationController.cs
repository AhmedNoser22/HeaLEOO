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
        [HttpGet]
        public IActionResult Index()
        {
            var specializations = _serviceSpecializations.GetAllSpecializations();
            return View(specializations);
        }
    }
}
