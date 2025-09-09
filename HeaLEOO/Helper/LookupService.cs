namespace HeaLEOO.Helper
{
    public class LookupService: IServiceLookup
    {
        private readonly AppDbContext _context;
        public LookupService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetAllAppointments()
        {
            return _context.Appointments.AsNoTracking()
                .Select(x => new SelectListItem { Text = x.App_Date.ToString("g"), Value = x.Id.ToString() })
                .ToList();
        }
    }
}
