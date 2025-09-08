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

        public async Task<IEnumerable<AppointmentsVM>> GetAllItems()
        {
            var appointments = await _genericRepo.GetAll();
            return _mapper.Map<IEnumerable<AppointmentsVM>>(appointments);
        }

        public async Task<AppointmentsVM> GetItemById(int id)
        {
            var appointments = await _genericRepo.GetById(id);
            return _mapper.Map<AppointmentsVM>(appointments);
        }

        public async Task<AppointmentsVM> CreateItem(AppointmentsVM appointments)
        {
            var apps = _mapper.Map<Appointments>(appointments);
            await _genericRepo.Add(apps);
            await _genericRepo.Complete();
            return _mapper.Map<AppointmentsVM>(apps);
        }





    }
}

