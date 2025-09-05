namespace HeaLEOO.Controllers
{
    public class ClinicsController : Controller
    {
        private readonly IServiceClinics _serviceClinics;
        private readonly IMapper _mapper;

        public ClinicsController(IServiceClinics serviceClinics, IMapper mapper)
        {
            _serviceClinics = serviceClinics;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var clinics = await _serviceClinics.GetAllClinicsAsync();
            var model = _mapper.Map<List<ClinicVM>>(clinics);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClinicVM model)
        {
            if (ModelState.IsValid)
            {
                var clinic = await _serviceClinics.AddClinicAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var clinic = await _serviceClinics.GetClinicByIdAsync(id);
            if (clinic == null)
            {
                return NotFound();
            }
            var model = await _serviceClinics.GetClinicByIdAsync(id);
            return View(model);
        }

        public async Task<IActionResult> DeleteClinic(int id)
        {
            var success = await _serviceClinics.DeleteClinicAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
