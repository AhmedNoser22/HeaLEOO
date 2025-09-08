namespace HeaLEOO.ALLServices
{
    public class ServiceAppointments : IServiceAppointments
    {
        private readonly IGenericRepo<Appointments> _genericRepo;
        private readonly IMapper _mapper;

        public ServiceAppointments(IGenericRepo<Appointments> genericRepo, IMapper mapper = null)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }


    }
}

