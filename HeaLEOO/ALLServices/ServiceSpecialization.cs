
namespace HeaLEOO.ALLServices
{
    public class ServiceSpecialization : IServiceSpecialization
    {
        private readonly IGenericRepo<Specializations> _repo;
        private readonly IMapper _mapper;

        public ServiceSpecialization(IGenericRepo<Specializations> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SpecializationsVM>> GetALLSepect()
        {
            var data = await _repo.GetAll();
            var result = data.Select(s => s.Name).ToList();
            var mapped = _mapper.Map<IEnumerable<SpecializationsVM>>(data);
            return mapped;
        }
    }
}
