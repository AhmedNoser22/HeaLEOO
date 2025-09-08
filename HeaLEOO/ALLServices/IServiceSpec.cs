namespace HeaLEOO.ALLServices
{
    public interface IServiceSpec
    {
        Task<IEnumerable<SpecializationsVM>> GetSpecializations();
        
    }
}
