namespace HeaLEOO.Controllers
{
    public class SpecializationController : Controller
    {
        private readonly IServiceSpec _serviceSpecializations;

        public SpecializationController(IServiceSpec serviceSpecializations)
        {
            _serviceSpecializations = serviceSpecializations;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var specializations = await _serviceSpecializations.GetSpecializations();
            return View(specializations);
        }
    }
}
