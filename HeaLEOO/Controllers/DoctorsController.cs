using HeaLEOO.DTOs;
using HeaLEOO.ServicesHel;
using Microsoft.AspNetCore.Mvc;

namespace HeaLEOO.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IServiceDoctors _doctorService;

        public DoctorsController(IServiceDoctors doctorService)
        {
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
        }

        // Mock specializations until ISpecializationService is available
        private List<Specializations> GetMockSpecializations()
        {
            return new List<Specializations>
            {
                new Specializations { Id = 1, Name = "Cardiology" },
                new Specializations { Id = 2, Name = "Dentistry" }
            };
        }

        // GET: /Doctor
        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorService?.GetAllDoctorsAsync() ?? new List<DoctorsDto>
            {
                new DoctorsDto { Id = 1, Name = "Dr. Ahmed Mohamed", phoneNumber = "0123456789", specializationId = 1 },
                new DoctorsDto { Id = 2, Name = "Dr. Sara Ali", phoneNumber = "0987654321", specializationId = 2 }
            };

            // Pass specializations for potential display in the view
            ViewBag.Specializations = GetMockSpecializations();

            return View(doctors);
        }

        // GET: /Doctor/Create
        public IActionResult Create()
        {
            ViewBag.Specializations = GetMockSpecializations();
            return View();
        }

        // POST: /Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorsDto doctorDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Specializations = GetMockSpecializations();
                return View(doctorDto);
            }

            try
            {
                // Business Logic: Validate required fields
                if (string.IsNullOrWhiteSpace(doctorDto.Name) || string.IsNullOrWhiteSpace(doctorDto.phoneNumber))
                {
                    ModelState.AddModelError("", "Doctor name or phone number is invalid.");
                    ViewBag.Specializations = GetMockSpecializations();
                    return View(doctorDto);
                }

                // Business Logic: Validate name length
                if (doctorDto.Name.Length < 3)
                {
                    ModelState.AddModelError("Name", "Doctor name must be at least 3 characters long.");
                    ViewBag.Specializations = GetMockSpecializations();
                    return View(doctorDto);
                }

                // Business Logic: Validate phone number format and length
                if (!System.Text.RegularExpressions.Regex.IsMatch(doctorDto.phoneNumber, @"^\d+$"))
                {
                    ModelState.AddModelError("phoneNumber", "Phone number must contain only digits.");
                    ViewBag.Specializations = GetMockSpecializations();
                    return View(doctorDto);
                }

                if (doctorDto.phoneNumber.Length < 10 || doctorDto.phoneNumber.Length > 11)
                {
                    ModelState.AddModelError("phoneNumber", "Phone number must be between 10 and 11 digits.");
                    ViewBag.Specializations = GetMockSpecializations();
                    return View(doctorDto);
                }

                // Business Logic: Validate specializationId
                var specializations = GetMockSpecializations();
                if (!specializations.Any(s => s.Id == doctorDto.specializationId))
                {
                    ModelState.AddModelError("specializationId", "Selected specialization is invalid.");
                    ViewBag.Specializations = specializations;
                    return View(doctorDto);
                }

                // Add the doctor
                await _doctorService.AddDoctorAsync(doctorDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error adding doctor: {ex.Message}");
                ViewBag.Specializations = GetMockSpecializations();
                return View(doctorDto);
            }
        }

        // POST: /Doctor/Delete/{id}
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