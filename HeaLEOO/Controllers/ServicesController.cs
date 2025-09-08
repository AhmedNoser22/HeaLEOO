namespace HeaLEOO.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceLM _serviceServices;
        private readonly IServiceClinDate _serviceClinDate;

        public ServicesController(IServiceLM serviceServices, IServiceClinDate serviceClinDate)
        {
            _serviceServices = serviceServices;
            _serviceClinDate = serviceClinDate;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _serviceServices.GetAll();
            return View(services);
        }
        public IActionResult Create()
        {
            var model = new ServiceVM
            {
                Clinics = _serviceClinDate.GetAllServiceClinDate()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Clinics = _serviceClinDate.GetAllServiceClinDate();
                return View(model);
            }

            await _serviceServices.Create(model);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var service = await _serviceServices.GetById(id);
            if (service == null) return NotFound();

            service.Clinics = _serviceClinDate.GetAllServiceClinDate();
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Clinics = _serviceClinDate.GetAllServiceClinDate();
                return View(model);
            }

            var result = await _serviceServices.Update(id, model);
            if (!result) return NotFound();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _serviceServices.GetById(id);
            if (service == null) return NotFound();

            return View(service);
        }
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _serviceServices.Delete(id);
            if (result)
                TempData["SuccessMessage"] = "Service deleted successfully.";
            else
                TempData["ErrorMessage"] = "Failed to delete service.";

            return RedirectToAction(nameof(Index));
        }
    }
}