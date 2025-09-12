namespace HeaLEOO.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IServiceAppointments _serviceAppointments;
        private readonly IServiceDoctorAppointment _ServiceDoctorAppointment;
        private readonly IServiceClinDate _ServiceClinDate;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AppointmentsController(IServiceAppointments serviceAppointments, IMapper mapper, UserManager<AppUser> userManager, IServiceDoctorAppointment serviceDoctorAppointment, IServiceClinDate serviceClinDate)
        {
            _serviceAppointments = serviceAppointments;
            _mapper = mapper;
            _userManager = userManager;
            _ServiceDoctorAppointment = serviceDoctorAppointment;
            _ServiceClinDate = serviceClinDate;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _serviceAppointments.GetAllItems();
            return View(appointments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new AppointmentsVM
            {
                SelectDoctors = _ServiceDoctorAppointment.GetAllServiceDoctorAppointment(),
                SelectClinics = _ServiceClinDate.GetAllServiceClinDate()
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentsVM model)
        {
            if (!ModelState.IsValid)
            {
                model.SelectDoctors = _ServiceDoctorAppointment.GetAllServiceDoctorAppointment();
                model.SelectClinics = _ServiceClinDate.GetAllServiceClinDate();
                return View(model);
            }

            var appointment = _mapper.Map<Appointments>(model);
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                ModelState.AddModelError("", "You must be logged in to create an appointment.");
                model.SelectDoctors = _ServiceDoctorAppointment.GetAllServiceDoctorAppointment();
                return View(model);
            }
            appointment.AppUserId = user.Id;

            await _serviceAppointments.CreateItem(appointment);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var appointment = await _serviceAppointments.GetItemById(id);
            if (appointment == null) return NotFound();

            return View(appointment);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _serviceAppointments.GetItemById(id);
            if (appointment == null) return NotFound();

            return View(appointment);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _serviceAppointments.DeleteItem(id);

            if (result) TempData["SuccessMessage"] = "Appointment deleted successfully.";
            else TempData["ErrorMessage"] = "Failed to delete appointment.";

            return RedirectToAction(nameof(Index));
        }
    }
}
