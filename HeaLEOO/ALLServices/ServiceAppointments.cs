
using HeaLEOO.ViewModels;

namespace HeaLEOO.ALLServices
{
    public class ServiceAppointments : IServiceAppointments
    {
        private readonly IGenericRepo<Appointments> _repo;
        private readonly IMapper _mapper;
        public ServiceAppointments(IGenericRepo<Appointments> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AppointmentsVM> AddAppAsync(AppointmentsVM appointmentsVM)
        {
            var appointments = _mapper.Map<Appointments>(appointmentsVM);
            await _repo.Add(appointments);
            await _repo.Complete();

            return _mapper.Map<AppointmentsVM>(appointmentsVM);
        }

        public async Task<bool> DeleteAppAsync(int id)
        {
            var appointments = await _repo.Delete(id);
            if (appointments != null)
            {
                await _repo.Complete();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<AppointmentsVM>> GetAllAppAsync()
        {
            var appointments = await _repo.GetAll();
            return _mapper.Map<IEnumerable<AppointmentsVM>>(appointments);
        }

        public async Task<AppointmentsVM> GetAppByIdAsync(int id)
        {
            var appointments = await _repo.GetById(id);
            return _mapper.Map<AppointmentsVM>(appointments);
        }
    }
}
