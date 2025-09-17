namespace HeaLEOO.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IUnitOF_Work _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IServiceDoctorAppointment _serviceDoctorAppointment;
        private readonly IServiceClinDate _serviceClinDate;
        private readonly UserManager<AppUser> _userManager;

        public AppointmentsController(
            IUnitOF_Work unitOfWork,
            IMapper mapper,
            IServiceDoctorAppointment serviceDoctorAppointment,
            IServiceClinDate serviceClinDate,
            UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serviceDoctorAppointment = serviceDoctorAppointment;
            _serviceClinDate = serviceClinDate;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _unitOfWork.GetRepoAppointments.GetAll(
                include: q => q
                    .Include(x => x.Doctors)
                    .Include(x => x.Clinics)
                    .Include(x => x.AppUser)
            );

            var mapped = _mapper.Map<IEnumerable<AppointmentsVM>>(data);
            return View(mapped);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new AppointmentsVM
            {
                SelectDoctors = _serviceDoctorAppointment.GetAllServiceDoctorAppointment(),
                SelectClinics = _serviceClinDate.GetAllServiceClinDate()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentsVM vm)
        {
            var user = await _userManager.GetUserAsync(User);

            var existing = await _unitOfWork.GetRepoAppointments.GetAll(
                x => x.AppUserId == user.Id
            );

            if (existing.Any())
            {
                TempData["Error"] = "You cannot book more than one appointment";
                vm.SelectDoctors = _serviceDoctorAppointment.GetAllServiceDoctorAppointment();
                vm.SelectClinics = _serviceClinDate.GetAllServiceClinDate();
                return View(vm);
            }

            var appointment = _mapper.Map<Appointments>(vm);
            appointment.AppUserId = user.Id;
            await _unitOfWork.GetRepoAppointments.Add(appointment);
            await _unitOfWork.Complete();

            TempData["Success"] = "Appointment booked successfully";
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var appointment = await _unitOfWork.GetRepoAppointments.GetById(
                id,
                include: q => q
                    .Include(x => x.Doctors)
                    .Include(x => x.Clinics)
                    .Include(x => x.AppUser)
            );

            if (appointment == null) return NotFound();

            var vm = _mapper.Map<AppointmentsVM>(appointment);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _unitOfWork.GetRepoAppointments.Delete(id);
            if (appointment == null) return NotFound();

            await _unitOfWork.Complete();
            TempData["Success"] = "Appointment deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}