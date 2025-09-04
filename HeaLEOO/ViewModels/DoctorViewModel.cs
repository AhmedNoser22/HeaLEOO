using Microsoft.AspNetCore.Mvc.Rendering;
namespace HeaLEOO.ViewModels
{
    public class DoctorViewModel
    {
            public int Id { get; set; }
            [Display(Name = "Doctor Name")]
            [Required(ErrorMessage = "Doctor name is required.")]
            public string Name { get; set; } = string.Empty;

            [Display(Name = "Phone Number")]
            [Required(ErrorMessage = "Phone number is required.")]
            [Phone(ErrorMessage = "Invalid phone number format.")]
            public string PhoneNumber { get; set; } = string.Empty;

            [Display(Name = "Specialization")]
            [Required(ErrorMessage = "Specialization is required.")]
            public int SpecializationId { get; set; }
            public IEnumerable<SelectListItem> Specializations { get; set; }
                = Enumerable.Empty<SelectListItem>();

            [Display(Name = "Clinics")]
            [Required(ErrorMessage = "At least one clinic must be selected.")]
            public List<int> ClinicIds { get; set; } = new();

            public IEnumerable<SelectListItem> Clinics { get; set; }
                = Enumerable.Empty<SelectListItem>();
            [Display(Name = "Appointments")]
            [Required(ErrorMessage = "At least one Appointment must be selected.")]
            public List<int> AppointmentsIds { get; set; } = new();
            public IEnumerable<SelectListItem> Appointments { get; set; }
                = Enumerable.Empty<SelectListItem>();
        }
}
