namespace HeaLEOO.ALLServices
{
    public interface IServiceAppointments
    {
        Task<IEnumerable<AppointmentsVM>> GetAllItems();
        Task<AppointmentsVM?> GetItemById(int id);
        Task<AppointmentsVM> CreateItem(Appointments appointment);
        Task<IEnumerable<AppointmentsVM>> GetAppointmentsWithUsers();
        Task<IEnumerable<AppointmentsVM>> GetAvailableAppointments(int doctorId, int clinicId);
        Task<bool> DeleteItem(int id);
    }
}
