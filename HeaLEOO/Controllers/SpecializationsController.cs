namespace HeaLEOO.Controllers
{
    public class SpecializationsController : Controller
    {
        private readonly IServiceSpec _serviceSpecializations;

        public SpecializationsController(IServiceSpec serviceSpecializations)
        {
            _serviceSpecializations = serviceSpecializations;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var specializations = await _serviceSpecializations.GetSpecializations();
            return View(specializations);
        }
        [HttpGet]
        public IActionResult AddSpecializations()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSpecializations(SpecializationsVM specializations)
        {
            if (ModelState.IsValid)
            {
                await _serviceSpecializations.Addspecializations(specializations);
                return RedirectToAction("Index");
            }
            return View(specializations);
        }
    }
}
