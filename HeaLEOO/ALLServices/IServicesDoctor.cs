namespace HeaLEOO.ALLServices
{
    public interface IServicesDoctor
    {
        Task<IEnumerable<DoctorViewModel>> GetAllItems();
    }
}
