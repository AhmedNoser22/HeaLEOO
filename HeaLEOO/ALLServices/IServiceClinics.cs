namespace HeaLEOO.ALLServices
{
    public interface IServiceClinics
    {
        Task<ClinicVM> AddClinicAsync(ClinicVM clinicVM, IFormFile? file = null);
        Task<IEnumerable<ClinicVM>> GetAllClinicsAsync();
        Task<ClinicVM> GetClinicByIdAsync(int id);
        Task<bool> DeleteClinicAsync(int id);
    }
}
