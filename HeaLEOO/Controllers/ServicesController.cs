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

    }
}