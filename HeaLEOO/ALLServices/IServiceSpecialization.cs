namespace HeaLEOO.ALLServices
{
    public interface IServiceSpecialization
    {
        Task<IEnumerable<SpecializationsVM>> GetSpecializations();
    }
}
