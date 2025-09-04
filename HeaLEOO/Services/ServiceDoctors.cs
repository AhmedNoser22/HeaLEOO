using HeaLEOO.DTOs;

namespace HeaLEOO.Services
{
    public class ServiceDoctors : IServiceDoctors
    {
        private readonly IGenericRepo<DoctorsDto> _repository;
        private IMapper _mapper;
        public ServiceDoctors(IGenericRepo<DoctorsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<DoctorsDto> AddDoctor(DoctorsDto doctor)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDoctor(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DoctorsDto>> GetAllDoctors()
        {
            var items = await _repository.GetAll();
            return _mapper.Map<IEnumerable<DoctorsDto>>(items);
        }

        public Task<DoctorsDto> GetDoctorById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
