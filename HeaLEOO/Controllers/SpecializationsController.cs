using HeaLEOO.ALLServices;
using HeaLEOO.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace HeaLEOO.Controllers
{
    public class SpecializationsController : Controller
    {
        private readonly IServiceSpec _serviceSpecializations;

        public SpecializationsController(IServiceSpec serviceSpecializations)
        {
            _serviceSpecializations = serviceSpecializations;
        }

    }
}
