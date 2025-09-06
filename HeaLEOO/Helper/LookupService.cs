public class LookupService : ILookupService
{
    private readonly AppDbContext _context;
    public LookupService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<SelectListItem> GetAllAppointments()
    {
        return _context.Appointments.AsNoTracking()
            .Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.App_Date.ToString("yyyy-MM-dd HH:mm")
            })
            .ToList();
    }
}