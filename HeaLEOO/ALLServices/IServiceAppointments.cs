namespace HeaLEOO.ALLServices
{
    public interface IServiceAppointments
    {
        Task<IEnumerable<AppointmentsVM>> GetAllItems();
        Task<AppointmentsVM> GetItemById(int id);
        Task<bool> CreateItem(AppointmentsVM model);
        Task<bool> DeletItem(int id);
    }
}
