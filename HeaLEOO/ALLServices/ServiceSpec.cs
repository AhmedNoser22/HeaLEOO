
namespace HeaLEOO.ALLServices
{
    public class ServiceSpec : IServiceSpec
    {
        private readonly IGenericRepo<Specializations> _genericRepo;
        private readonly IMapper _mapper;
        public ServiceSpec(IGenericRepo<Specializations> genericRepo, IMapper mapper = null)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SpecializationsVM>> GetSpecializations()
        {
            var specializations =await _genericRepo.GetAll();
            return _mapper.Map<IEnumerable<SpecializationsVM>>(specializations);
        }
        public async Task<SpecializationsVM> Addspecializations(SpecializationsVM specializations)
        {
            var spec = _mapper.Map<Specializations>(specializations);
            await _genericRepo.Add(spec);
            await _genericRepo.Complete();
            return _mapper.Map<SpecializationsVM>(spec);

        }

       
    }
}
