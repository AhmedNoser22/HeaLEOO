namespace HeaLEOO.ALLServices
{
    public class ServicesDoctor: IServicesDoctor
    {
        private readonly IGenericRepo<Doctors> _genericRepo;
        private readonly IMapper _mapper;
        private readonly IserviceSpecializations _serviceSpecializations;
        private readonly IServiceClinDate _serviceClinDate;

        public ServicesDoctor(
            IGenericRepo<Doctors> genericRepo,
            IMapper mapper,
            IserviceSpecializations serviceSpecializations,
            IServiceClinDate serviceClinDate)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
            _serviceSpecializations = serviceSpecializations;
            _serviceClinDate = serviceClinDate;
        }

        public async Task<IEnumerable<DoctorViewModel>> GetAllItems()
        {
            var doctors = await _genericRepo.GetAll(query =>
                query.Include(d => d.specializations)
                     .Include(d => d.ClinicDoctors)
                     .ThenInclude(cd => cd.Clinic)
            );
            return _mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
        }
    }
}
