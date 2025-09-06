namespace HeaLEOO.Helper
{
    public class ServiceClinDate:IServiceClinDate
    {
        private readonly AppDbContext _context;
        public ServiceClinDate(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem>GetAllServiceClinDate()
        {
            return _context.Clinics.AsNoTracking()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                .ToList();
        }
    }
}
