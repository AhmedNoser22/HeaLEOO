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
            var result = _context.Specializations.Select
                (
                x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }
                ).AsNoTracking().ToList();
            return result;
        }

    }
}
