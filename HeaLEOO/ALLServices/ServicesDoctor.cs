namespace HeaLEOO.ALLServices
{
    public class ServicesDoctor: IServicesDoctor
    {
        private readonly IUnitOF_Work work;
        private readonly IMapper _mapper;
        private readonly IserviceSpecializations _serviceSpecializations;
        private readonly IServiceClinDate _serviceClinDate;

        public ServicesDoctor(
            IMapper mapper,
            IserviceSpecializations serviceSpecializations,
            IServiceClinDate serviceClinDate,
            IUnitOF_Work work)
        {
            _mapper = mapper;
            _serviceSpecializations = serviceSpecializations;
            _serviceClinDate = serviceClinDate;
            this.work = work;
        }

        public async Task<IEnumerable<DoctorViewModel>> GetAllItems()
        {
            var doctors = await work.GetRepoDoctors.GetAll(query =>
                query.Include(d => d.specializations)
                     .Include(d => d.ClinicDoctors)
                     .ThenInclude(cd => cd.Clinic)
            );
            return _mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
        }

        public async Task<DoctorViewModel> GetItemById(int id)
        {
            var doctor = await work.GetRepoDoctors.GetById(id);
            if (doctor == null) return null!;
            var model = _mapper.Map<DoctorViewModel>(doctor);
            model.Specializations = _serviceSpecializations.GetAllSpecializations();
            model.Clinics = _serviceClinDate.GetAllServiceClinDate();
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

            await work.GetRepoDoctors.Add(entity);
            await work.Complete();
            return true;
        }

        public async Task<bool> DeletItem(int id)
        {
            var entity = await work.GetRepoDoctors.GetById(id);
            if (entity == null) return false;
            await work.GetRepoDoctors.Delete(id);
            await work.Complete();
            return true;
        }

    }
}
