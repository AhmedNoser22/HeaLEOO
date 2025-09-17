namespace HeaLEOO.ALLServices
{
    public class ServiceAppointments : IServiceAppointments
    {
        private readonly IUnitOF_Work work;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ServiceAppointments(
            IUnitOF_Work work,
            IMapper mapper,
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            this.work = work;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
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
        public async Task<AppointmentsVM?> CreateItem(AppointmentsVM appointment)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext!.User);

            var existing = await work.GetRepoAppointments.GetAll(
                x => x.AppUserId == user.Id
            );

            if (existing.Any())
            {
                return null;
            }

            var entity = _mapper.Map<Appointments>(appointment);
            entity.AppUserId = user.Id;

            await work.GetRepoAppointments.Add(entity);
            await work.Complete();

            return _mapper.Map<AppointmentsVM>(entity);
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