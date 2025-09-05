using Microsoft.AspNetCore.Mvc;

namespace HeaLEOO.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceLM _serviceServices;
        private readonly IMapper _mapper;

        public ServicesController(IServiceLM serviceServices, IMapper mapper)
        {
            _serviceServices = serviceServices;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _serviceServices.GetAllAsync();
            return View(services);
        }

        public IActionResult Create()
        {
            var model = new ServiceVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _serviceServices.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var service = await _serviceServices.GetByIdAsync(id);
            if (service == null) return NotFound();
            return View(service);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var service = await _serviceServices.GetByIdAsync(id);
            if (service == null) return NotFound();
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _serviceServices.UpdateAsync(id, model);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _serviceServices.GetByIdAsync(id);
            if (service == null) return NotFound();
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _serviceServices.DeleteAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Service deleted successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete service.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
