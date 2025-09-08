namespace HeaLEOO.ALLServices
{
    public interface IServicesDoctor
    {
        Task<IEnumerable<DoctorViewModel>> GetAllItems();
        Task<DoctorViewModel> GetItemById(int id);
    }
}
