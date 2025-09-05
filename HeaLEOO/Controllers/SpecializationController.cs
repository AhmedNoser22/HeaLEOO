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
        public async Task<IActionResult> Index()
        {
            var data = await _serviceSpecializations.
            return View(data);
        }
    }
}
