namespace HeaLEOO.ALLServices
{
    public interface IServiceAppointments
    {
        Task<IEnumerable<AppointmentsVM>> GetAllItems();

    }
}
