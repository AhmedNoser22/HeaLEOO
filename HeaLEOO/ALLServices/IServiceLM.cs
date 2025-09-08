using HeaLEOO.ViewModels;

namespace HeaLEOO.ALLServices
{
    public interface IServiceLM
    {
        Task<IEnumerable<ServiceVM>> GetAll();
        Task<ServiceVM?> GetById(int id);
        Task<bool> Create(ServiceVM vm);
        Task<bool> Update(int id, ServiceVM vm);
        Task<bool> Delete(int id);



    }
}
