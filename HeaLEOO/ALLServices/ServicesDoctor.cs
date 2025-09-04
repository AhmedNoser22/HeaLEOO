namespace HeaLEOO.ALLServices
{
    public class ServicesDoctor : IServicesDoctor
    {
        private readonly IGenericRepo<Doctors> _genericRepo;
        private readonly IMapper _mapper;
        private readonly IserviceSpecializations _serviceSpecializations;
        private readonly IserviceClinics _serviceClinics;
        private readonly IserviceAppointments _serviceAppointments;

        public ServicesDoctor(
            IGenericRepo<Doctors> genericRepo,
            IMapper mapper,
            IserviceSpecializations serviceSpecializations,
            IserviceClinics serviceClinics,
            IserviceAppointments serviceAppointments)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
            _serviceSpecializations = serviceSpecializations;
            _serviceClinics = serviceClinics;
            _serviceAppointments = serviceAppointments;
        }
        public async Task<IEnumerable<DoctorViewModel>> GetAllItems()
        {
            var doctors = await _genericRepo.GetAll(x => x.specializations, x => x.ClinicDoctors, x => x.Appointments);
            return _mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
        }
        public async Task<DoctorViewModel> GetItemById(int id)
        {
            var doctor = await _genericRepo.GetById(id);
            if (doctor == null) return null!;
            var model = _mapper.Map<DoctorViewModel>(doctor);
            model.Specializations = _serviceSpecializations.GetAllSpecializations();
            model.Clinics = _serviceClinics.GetAllClinics();
            model.Appointments = _serviceAppointments.GetAllAppointments();

            return model;
        }
        public async Task<bool> CreateItem(DoctorViewModel model)
        {
            var entity = _mapper.Map<Doctors>(model);
            await _genericRepo.Add(entity);
            await _genericRepo.Complete();
            return true;
        }
        public async Task<bool> DeletItem(int id)
        {
            var entity = await _genericRepo.GetById(id);
            if (entity == null) return false;
            await _genericRepo.Delete(id);
            await _genericRepo.Complete();
            return true;
        }
    }
}