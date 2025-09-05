namespace HeaLEOO.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IServicesDoctor _serviceDoctor;
        private readonly IserviceSpecializations _serviceSpecializations;
        private readonly IserviceClinics _serviceClinics;
        private readonly IMapper _mapper;

        public DoctorsController(IServicesDoctor serviceDoctor, IserviceSpecializations serviceSpecializations, IserviceClinics serviceClinics, IMapper mapper)
        {
            _serviceDoctor = serviceDoctor;
            _serviceSpecializations = serviceSpecializations;
            _serviceClinics = serviceClinics;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var doctors = await _serviceDoctor.GetAllItems();
            return View(doctors);
        }

        public IActionResult Create()
        {
            var model = new DoctorViewModel
            {
                Specializations = _serviceSpecializations.GetAllSpecializations(),
                Clinics = _serviceClinics.GetAllClinics()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Specializations = _serviceSpecializations.GetAllSpecializations();
                model.Clinics = _serviceClinics.GetAllClinics();
                return View(model);
            }
            await _serviceDoctor.CreateItem(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _serviceDoctor.GetItemById(id);
            if (doctor == null) return NotFound();
            return View(doctor);
        }
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _serviceDoctor.DeletItem(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Doctor deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete doctor.";
            }

            return RedirectToAction(nameof(Index));
        }

    }

}