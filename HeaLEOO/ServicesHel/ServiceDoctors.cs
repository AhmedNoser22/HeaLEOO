using HeaLEOO.DTOs;
namespace HeaLEOO.ServicesHel
{
    public class ServiceDoctors : IServiceDoctors
    {
        private readonly IGenericRepo<Doctors> _doctorRepo;
        private readonly IMapper _mapper;
        public ServiceDoctors(IGenericRepo<Doctors> doctorRepo, IMapper mapper)
        {
            _doctorRepo = doctorRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorsDto>> GetAllDoctorsAsync()
        {
            var doctors =await _doctorRepo.GetAll();
            return _mapper.Map<IEnumerable<DoctorsDto>>(doctors);
        }

        public async Task<DoctorsDto> GetDoctorByIdAsync(int id)
        {
            var doctor =await _doctorRepo.GetById(id);
            return _mapper.Map<DoctorsDto>(doctor);
        }
        public async Task<DoctorsDto> AddDoctorAsync(DoctorsDto doctorDto)
        {
            var doctor = _mapper.Map<Doctors>(doctorDto);
            var addedDoctor =await _doctorRepo.Add(doctor);
            await _doctorRepo.Complete();    
            return _mapper.Map<DoctorsDto>(addedDoctor);
        }
        // nm;vvvvvvvvvvvvvvllll
        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var getId = await _doctorRepo.GetById(id);
            if(getId == null)
            {
                return false;
            }
            var deletedDoctor =await _doctorRepo.Delete(id);
            if(deletedDoctor != null)
            {
                await _doctorRepo.Complete();
                return true;
            }
            return false;
        }

        
    }
}
