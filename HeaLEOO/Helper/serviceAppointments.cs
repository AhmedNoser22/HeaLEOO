namespace HeaLEOO.Helper
{
    public class serviceAppointments: IserviceAppointments
    {
        private readonly AppDbContext _context;
        public serviceAppointments(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetAllAppointments()
        {
            var result = _context.Specializations.Select
                (
                x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }
                ).AsNoTracking().ToList();
            return result;
        }
    }
}
