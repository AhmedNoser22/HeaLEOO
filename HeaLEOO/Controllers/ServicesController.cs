using Microsoft.AspNetCore.Mvc;

namespace HeaLEOO.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceLM _serviceLM;
        private readonly IMapper _mapper;

        public ServicesController(IServiceLM serviceLM, IMapper mapper)
        {
            _serviceLM = serviceLM;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var model = new ServiceVM();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult DeleteService(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
