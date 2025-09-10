namespace HeaLEOO.ALLServices
{
    public class ServiceAppointments : IServiceAppointments
    {
        private readonly IUnitOF_Work work;
        private readonly IMapper _mapper;

        public ServiceAppointments(IMapper mapper, IUnitOF_Work work)
        {
            _mapper = mapper;
            this.work = work;
        }
        public async Task<IEnumerable<AppointmentsVM>> GetAllItems()
        {
            var appointments = await work.GetRepoAppointments.GetAll(include: q =>
                q.Include(a => a.Doctors)
                 .Include(a => a.Clinics)
                 .Include(a => a.AppUser));

            return _mapper.Map<IEnumerable<AppointmentsVM>>(appointments);
        }
        public async Task<AppointmentsVM?> GetItemById(int id)
        {
            var appointment = await work.GetRepoAppointments.GetById(id,
                q => q.Include(a => a.Doctors)
                      .Include(a => a.Clinics)
                      .Include(a => a.AppUser));

            return _mapper.Map<AppointmentsVM>(appointment);
        }
        public async Task<AppointmentsVM> CreateItem(Appointments appointment)
        {
            await work.GetRepoAppointments.Add(appointment);
            await work.Complete();

            return _mapper.Map<AppointmentsVM>(appointment);
        }
        public async Task<IEnumerable<AppointmentsVM>> GetAppointmentsWithUsers()
        {
            var appointments = await work.GetRepoAppointments.GetAll(include: q =>
                q.Include(a => a.AppUser)
                 .Include(a => a.Doctors)
                 .Include(a => a.Clinics));

            return _mapper.Map<IEnumerable<AppointmentsVM>>(appointments);
        }
        public async Task<IEnumerable<AppointmentsVM>> GetAvailableAppointments(int doctorId, int clinicId)
        {
            var appointments = await work.GetRepoAppointments.GetAll(
                a => a.DoctorId == doctorId && a.ClinicId == clinicId && a.isActive == true,
                q => q.Include(a => a.Doctors).Include(a => a.Clinics));

            return _mapper.Map<IEnumerable<AppointmentsVM>>(appointments);
        }
        public async Task<bool> DeleteItem(int id)
        {
            var appointment = await work.GetRepoAppointments.GetById(id);
            if (appointment == null) return false;

            await work.GetRepoAppointments.Delete(id);
            await work.Complete();
            return true;
        }
    }
}
