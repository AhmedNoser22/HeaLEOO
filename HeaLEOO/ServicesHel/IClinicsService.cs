namespace HeaLEOO.ServicesHel
{
    public interface IClinicsService
    {
        Task<List<Clinics>> GetAllAsync();
        Task<Clinics?> GetByIdAsync(int id);
        Task<Clinics> CreateAsync(Clinics clinic);
        Task<bool> DeleteAsync(int id);
    }
}
