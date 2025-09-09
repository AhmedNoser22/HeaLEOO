namespace HeaLEOO.ALLServices
{
    public class ServiceAppointments : IServiceAppointments
    {
        private readonly IUnitOF_Work work;
        private readonly IMapper _mapper;

        public ServiceAppointments(IMapper mapper,IUnitOF_Work work)
        {
            _mapper = mapper;
            this.work = work;
        }

        public async Task<IEnumerable<AppointmentsVM>> GetAllItems()
        {
            var appointments = await work.GetRepoAppointments.GetAll();
            return _mapper.Map<IEnumerable<AppointmentsVM>>(appointments);
        }

        public async Task<AppointmentsVM> GetItemById(int id)
        {
            var appointments = await work.GetRepoAppointments.GetById(id);
            return _mapper.Map<AppointmentsVM>(appointments);
        }
        public async Task<AppointmentsVM> CreateItem(AppointmentsVM appointments)
        {
            var apps = _mapper.Map<Appointments>(appointments);
            await work.GetRepoAppointments.Add(apps);
            await work.Complete();
            return _mapper.Map<AppointmentsVM>(apps);
        }
        public async Task<bool> DeletItem(int id)
        {
            var appointments = await work.GetRepoAppointments.GetById(id);
            if (appointments == null) return false;

            await work.GetRepoAppointments.Delete(id);
            await work.Complete();
            return true;
        }



    }
}

