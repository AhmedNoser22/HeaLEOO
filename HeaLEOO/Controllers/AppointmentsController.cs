using Microsoft.AspNetCore.Mvc;

namespace HeaLEOO.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IServiceAppointments _serviceAppointments;
        private readonly IMapper _mapper;

        public AppointmentsController(IServiceAppointments serviceAppointments, IMapper mapper)
        {
            _serviceAppointments = serviceAppointments;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _serviceAppointments.GetAllItems();
            return View(appointments);
        }

        public IActionResult Create()
        {
            var model = new AppointmentsVM();
            return View(model);
        }


    }
}
