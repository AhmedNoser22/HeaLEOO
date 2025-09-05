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
            var data = _serviceSpecializations.GetAllSpecializations();
            return View(data);
        }
    }
}
