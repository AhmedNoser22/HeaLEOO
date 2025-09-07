
namespace HeaLEOO.ALLServices
{
    public class ServiceAppointments : IServiceAppointments
    {
        private readonly IGenericRepo<Appointments> _genericRepo;
        private readonly IMapper _mapper;

        public Task<bool> CreateItem(AppointmentsVM model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentsVM>> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentsVM> GetItemById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
