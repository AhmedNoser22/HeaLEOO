using Microsoft.AspNetCore.Mvc.Rendering;

namespace HeaLEOO.Helper
{
    public interface IserviceSpecializations
    {
        IEnumerable<SelectListItem> GetAllSpecializations();
    }
}
