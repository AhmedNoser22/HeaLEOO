namespace HeaLEOO.ALLServices
{
    public interface IServiceSpecialization
    {
        Task<IEnumerable<SpecializationsVM>> GetSpecializations();
        Task<SpecializationsVM> Addspecializations(SpecializationsVM specializations);
    }
}
