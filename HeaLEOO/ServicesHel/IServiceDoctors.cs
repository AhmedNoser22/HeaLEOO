using HeaLEOO.DTOs;

namespace HeaLEOO.ServicesHel
{
    public interface IServiceDoctors
    {
        Task<IEnumerable<DoctorsDto>> GetAllDoctorsAsync();
        Task<DoctorsDto> GetDoctorByIdAsync(int id);
        Task<DoctorsDto> AddDoctorAsync(DoctorsDto doctorDto);
        Task<bool> DeleteDoctorAsync(int id);
    }
}
