using HeaLEOO.DTOs;

namespace HeaLEOO.Services
{
    public interface IServiceDoctors
    {
        Task<IEnumerable<DoctorsDto>> GetAllDoctors();
        Task<DoctorsDto> GetDoctorById(int id);
        Task<DoctorsDto> AddDoctor(DoctorsDto doctor);
        Task<bool> DeleteDoctor(int id);
    }

}
