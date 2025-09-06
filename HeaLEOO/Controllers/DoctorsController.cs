namespace HeaLEOO.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IServicesDoctor _serviceDoctor;
        private readonly IserviceSpecializations _serviceSpecializations;
        private readonly IServiceClinicsDB _serviceClinicsDB;
        private readonly IMapper _mapper;

        public DoctorsController(IServicesDoctor serviceDoctor, IserviceSpecializations serviceSpecializations, IServiceClinicsDB serviceClinDate, IMapper mapper)
        {
            _serviceDoctor = serviceDoctor;
            _serviceSpecializations = serviceSpecializations;
            _serviceClinicsDB = serviceClinDate;
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