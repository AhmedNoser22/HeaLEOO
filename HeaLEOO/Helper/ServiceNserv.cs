namespace HeaLEOO.Helper
{
    public class ServiceNserv:IServiceNserv
    {
        private readonly AppDbContext _context;
        public ServiceNserv(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetAllServices()
        {
            return _context.Services.AsNoTracking()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                .ToList();
        }
    }
}
