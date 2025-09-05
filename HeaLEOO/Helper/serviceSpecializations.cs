using Microsoft.AspNetCore.Mvc.Rendering;
namespace HeaLEOO.Helper
{
    public class serviceSpecializations: IserviceSpecializations
    {
        private readonly AppDbContext _context;
        public serviceSpecializations(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetAllSpecializations()
        {
            return _context.Specializations.AsNoTracking()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                .ToList();
        }


    }
}
