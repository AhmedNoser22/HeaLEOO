namespace HeaLEOO.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IServiceAppointments _serviceAppointments;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public AppointmentsController(IServiceAppointments serviceAppointments, IMapper mapper, UserManager<AppUser> userManager)
        {
            _serviceAppointments = serviceAppointments;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var appointments = await _serviceAppointments.GetAllItems();
            return View(appointments);
        }
        public async Task<IActionResult> Available(int doctorId, int clinicId)
        {
            var appointments = await _serviceAppointments.GetAvailableAppointments(doctorId, clinicId);
            return View(appointments);
        }
        public async Task<IActionResult> AllReservations()
        {
            var appointments = await _serviceAppointments.GetAppointmentsWithUsers();
            return View(appointments);
        }
        public IActionResult Create()
        {
            var model = new AppointmentsVM();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentsVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var appointment = _mapper.Map<Appointments>(model);
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
