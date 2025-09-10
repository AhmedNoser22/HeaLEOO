namespace HeaLEOO.Helper
{
    public class ServiceDoctorAppointment: IServiceDoctorAppointment
    {
        private readonly AppDbContext _context;
            public ServiceDoctorAppointment(AppDbContext context)
            {
                _context = context;
            }
            public IEnumerable<SelectListItem> GetAllServiceDoctorAppointment()
            {
                return _context.Doctors.AsNoTracking()
                    .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                    .ToList();
            }
        }
}
