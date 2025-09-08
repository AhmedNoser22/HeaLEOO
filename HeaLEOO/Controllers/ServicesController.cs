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
    }
}