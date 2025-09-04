namespace HeaLEOO.Helper
{
    public class serviceClinics: IserviceClinics
    {
        private readonly AppDbContext _context;
        public serviceClinics(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetAllClinics()
        {
            var result = _context.Clinics.Select
                (
                x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }
                ).AsNoTracking().ToList();
            return result;
        }
    }
}
