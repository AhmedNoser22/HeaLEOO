namespace HeaLEOO.ALLServices
{
    public interface IServiceLM
    {
        Task<IEnumerable<ServiceVM>> GetAllAsync();
        

    }
}
