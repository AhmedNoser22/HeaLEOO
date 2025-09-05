namespace HeaLEOO.ALLServices
{
    public interface IServiceLM
    {
        Task<IEnumerable<ServiceVM>> GetAllAsync();
        Task<ServiceVM?> GetByIdAsync(int id);
        Task<ServiceVM> CreateAsync(ServiceVM vm);
        Task<bool> UpdateAsync(int id, ServiceVM vm);
        Task<bool> DeleteAsync(int id);
    }
}
