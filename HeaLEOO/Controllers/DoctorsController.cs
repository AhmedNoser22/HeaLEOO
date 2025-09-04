using HeaLEOO.DTOs;
using HeaLEOO.Services;
using HeaLEOO.ServicesHel;
using Microsoft.AspNetCore.Mvc;

namespace HeaLEOO.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IServiceDoctors _doctorService;
        private readonly IClinicsService _clinicsService;
        private readonly AppDbContext _context; 

        public DoctorsController(IServiceDoctors doctorService, IClinicsService clinicsService, AppDbContext context)
        {
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
            _clinicsService = clinicsService ?? throw new ArgumentNullException(nameof(clinicsService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: /Doctors
        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            ViewBag.Specializations = _context.Specializations.ToList();
            ViewBag.Clinics = await _clinicsService.GetAllAsync();
            return View(doctors);
        }

        // GET: /Doctors/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            ViewBag.Specializations = _context.Specializations.ToList();
            ViewBag.Clinics = await _clinicsService.GetAllAsync();
            return View(doctor);
        }

        // GET: /Doctors/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Specializations = _context.Specializations.ToList();
            ViewBag.Clinics = await _clinicsService.GetAllAsync();
            return View();
        }

        // POST: /Doctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorsDto doctorDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Specializations = _context.Specializations.ToList();
                ViewBag.Clinics = await _clinicsService.GetAllAsync();
                return View(doctorDto);
            }

            try
            {
                await _doctorService.AddDoctorAsync(doctorDto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error adding doctor: {ex.Message}");
                ViewBag.Specializations = _context.Specializations.ToList();
                ViewBag.Clinics = await _clinicsService.GetAllAsync();
                return View(doctorDto);
            }
        }

        // GET: /Doctors/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            ViewBag.Specializations = _context.Specializations.ToList();
            ViewBag.Clinics = await _clinicsService.GetAllAsync();
            return View(doctor);
        }

        // POST: /Doctors/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DoctorsDto doctorDto)
        {
            if (id != doctorDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Specializations = _context.Specializations.ToList();
                ViewBag.Clinics = await _clinicsService.GetAllAsync();
                return View(doctorDto);
            }

            try
            {
                await _doctorService.AddDoctorAsync(doctorDto); 
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating doctor: {ex.Message}");
                ViewBag.Specializations = _context.Specializations.ToList();
                ViewBag.Clinics = await _clinicsService.GetAllAsync();
                return View(doctorDto);
            }
        }

        // POST: /Doctors/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _doctorService.DeleteDoctorAsync(id);
                if (!result)
                {
                    TempData["Error"] = "Doctor not found.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error deleting doctor: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}