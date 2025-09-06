namespace HeaLEOO.ALLServices
{
    public interface IServiceClinicsDB
    {
        Task<IEnumerable<ClinicVM>> GetAllClinicsAsync();
        Task<ClinicVM> GetClinicByIdAsync(int id);
        Task<ClinicVM> AddClinicAsync(ClinicVM clinicVM, IFormFile? file = null);
        Task<bool> DeleteClinicAsync(int id);
    }
}
