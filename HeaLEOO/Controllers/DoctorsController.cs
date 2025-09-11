namespace HeaLEOO.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IServicesDoctor _serviceDoctor;
        private readonly IserviceSpecializations _serviceSpecializations;
        private readonly IServiceClinDate _serviceClinicsDate;
        private readonly IMapper _mapper;

        public DoctorsController(
            IServicesDoctor serviceDoctor,
            IserviceSpecializations serviceSpecializations,
            IServiceClinDate _serviceClinDate,
            IMapper mapper)
        {
            _serviceDoctor = serviceDoctor;
            _serviceSpecializations = serviceSpecializations;
            _serviceClinicsDate = _serviceClinDate;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await _serviceDoctor.GetAllItems();
            return View(doctors);
        }





    }
}
