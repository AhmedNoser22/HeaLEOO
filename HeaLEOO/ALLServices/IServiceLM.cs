namespace HeaLEOO.ALLServices
{
    public interface IServiceLM
    {
        Task<IEnumerable<ServiceVM>> GetAllAsync();
        Task<ServiceVM?> GetByIdAsync(int id);
        Task<ServiceVM> CreateAsync(ServiceVM vm);
      


    }
}
