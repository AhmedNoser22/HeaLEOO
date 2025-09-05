namespace HeaLEOO.ALLServices
{
    public interface IServiceAppointments
    {
        Task<AppointmentsVM> AddAppAsync(AppointmentsVM appointmentsVM);
        Task<IEnumerable<AppointmentsVM>> GetAllAppAsync();
        Task<AppointmentsVM> GetAppByIdAsync(int id);
        Task<bool> DeleteAppAsync(int id);
    }
}
