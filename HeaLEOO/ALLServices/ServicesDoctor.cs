namespace HeaLEOO.ALLServices
{
    public class ServicesDoctor : IServicesDoctor
    {
        private readonly IGenericRepo<Doctors> _genericRepo;
        private readonly IMapper _mapper;
        private readonly IserviceSpecializations _serviceSpecializations;
        private readonly IserviceClinics _serviceClinics;

        public ServicesDoctor(IGenericRepo<Doctors> genericRepo, IMapper mapper, IserviceSpecializations serviceSpecializations, IserviceClinics serviceClinics)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
            _serviceSpecializations = serviceSpecializations;
            _serviceClinics = serviceClinics;
        }

        public async Task<IEnumerable<DoctorViewModel>> GetAllItems()
        {
            var doctors = await _genericRepo.GetAll
                (
                query =>
                query.Include(d => d.specializations)
                .Include(d => d.ClinicDoctors)
                .ThenInclude(cd => cd.Clinic)
            );

            return _mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
        }

        public async Task<DoctorViewModel> GetItemById(int id)
        {
            var doctor = await _genericRepo.GetById(id);
            if (doctor == null) return null!;
            var model = _mapper.Map<DoctorViewModel>(doctor);
            model.Specializations = _serviceSpecializations.GetAllSpecializations();
            model.Clinics = _serviceClinics.GetAllClinics();
            return model;
        }

        public async Task<bool> CreateItem(DoctorViewModel model)
        {
            var entity = _mapper.Map<Doctors>(model);
            if (model.ClinicIds != null && model.ClinicIds.Any())
            {
                foreach (var clinicId in model.ClinicIds)
                {
                    entity.ClinicDoctors.Add(new ClinicDoctors
                    {
                        Doctor = entity,
                        ClinicId = clinicId
                    });
                }
            }

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