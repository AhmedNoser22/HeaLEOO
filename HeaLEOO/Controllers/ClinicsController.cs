using Microsoft.AspNetCore.Mvc;

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
            // call service to get all clinics //
            return View();
        }

        public IActionResult Create()
        {
            // return empty VM for clinic creation //
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClinicVM model)
        {
            if (!ModelState.IsValid)
            {
                // return same model with validation messages //
                return View(model);
            }

            // call service to add new clinic //
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            // get clinic by id from service //
            return View();
        }

        public async Task<IActionResult> DeleteClinic(int id)
        {
            // call service to delete clinic by id //

            return RedirectToAction(nameof(Index));
        }
    }
}
