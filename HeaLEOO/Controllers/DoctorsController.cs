using HeaLEOO.DTOs;
using HeaLEOO.Services;
using HeaLEOO.ServicesHel;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace HeaLEOO.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IServiceDoctors _doctorService;
        private readonly IClinicsService _clinicsService;
        //Coment...//
        public DoctorsController(IServiceDoctors doctorService, IClinicsService clinicsService)
        {
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
            _clinicsService = clinicsService ?? throw new ArgumentNullException(nameof(clinicsService));
        }

        // GET: /Doctors
        public async Task<IActionResult> Index()
        {
            var doctors = (await _doctorService.GetAllDoctorsAsync() as List<DoctorsDto>) ?? new List<DoctorsDto>();
            var clinics = await _clinicsService.GetAllAsync() ?? new List<Clinics>();
            return View(Tuple.Create(doctors, clinics));
        }

        // GET: /Doctors/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            var clinics = await _clinicsService.GetAllAsync() ?? new List<Clinics>();
            return View(Tuple.Create(doctor, clinics));
        }

        // GET: /Doctors/Create
        public async Task<IActionResult> Create()
        {
            var clinics = await _clinicsService.GetAllAsync() ?? new List<Clinics>();
            return View(clinics);
        }

        // POST: /Doctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorsDto doctorDto, List<Clinics> clinics)
        {
            if (!ModelState.IsValid)
            {
                return View(clinics);
            }

            // Business Logic: Validate required fields
            if (string.IsNullOrWhiteSpace(doctorDto.Name) || string.IsNullOrWhiteSpace(doctorDto.phoneNumber))
            {
                ModelState.AddModelError("", "Doctor name or phone number is invalid.");
                return View(clinics);
            }

            // Business Logic: Validate name length
            if (doctorDto.Name.Length < 3)
            {
                ModelState.AddModelError("Name", "Doctor name must be at least 3 characters long.");
                return View(clinics);
            }

            // Business Logic: Validate phone number format and length
            if (!Regex.IsMatch(doctorDto.phoneNumber, @"^\d+$"))
            {
                ModelState.AddModelError("phoneNumber", "Phone number must contain only digits.");
                return View(clinics);
            }

            if (doctorDto.phoneNumber.Length < 10 || doctorDto.phoneNumber.Length > 11)
            {
                ModelState.AddModelError("phoneNumber", "Phone number must be between 10 and 11 digits.");
                return View(clinics);
            }

            // Business Logic: Validate ClinicIds
            var availableClinics = await _clinicsService.GetAllAsync() ?? new List<Clinics>();
            if (doctorDto.ClinicIds != null && doctorDto.ClinicIds.Any())
            {
                foreach (var clinicId in doctorDto.ClinicIds)
                {
                    if (!availableClinics.Any(c => c.Id == clinicId))
                    {
                        ModelState.AddModelError("ClinicIds", $"Invalid clinic ID: {clinicId}.");
                        return View(clinics);
                    }
                }
            }

            try
            {
                var addedDoctor = await _doctorService.AddDoctorAsync(doctorDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error adding doctor: {ex.Message}");
                return View(clinics);
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
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error deleting doctor: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}