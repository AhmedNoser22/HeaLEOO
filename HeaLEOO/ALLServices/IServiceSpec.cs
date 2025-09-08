namespace HeaLEOO.ALLServices
{
    public interface IServiceSpec
    {
        Task<IEnumerable<SpecializationsVM>> GetSpecializations();
        Task<SpecializationsVM> Addspecializations(SpecializationsVM specializations);
    }
}
