namespace HeaLEOO.Helper
{
    public class ServiceClinic : IServiceClinic
    {
        private readonly AppDbContext _connext;
        public ServiceClinic(AppDbContext connext)
        {
            _connext = connext;
        }

        public IEnumerable<SelectListItem> GetAllServices()
        {
            return _connext.Services.AsNoTracking()
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToList();
        }
    }
}
