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




        }
    }
