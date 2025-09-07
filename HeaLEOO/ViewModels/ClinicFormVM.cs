namespace HeaLEOO.ViewModels
{
    public class ClinicFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;

        [AllowedAttribute(FileSetting.AllowedImageTypes)]
        [MaxSizeAttribute(FileSetting.MaxImageSize)]
        public IFormFile? Photo { get; set; }
        public string? ExistingPhotoUrl { get; set; }

        [Display(Name = "Appointment")]
        [Required(ErrorMessage = "Appointment is required.")]
        public int AppointmentId { get; set; }
        public IEnumerable<SelectListItem> Appointments { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Service")]
        [Required(ErrorMessage = "Service is required.")]
        public int ServiceId { get; set; }
        public IEnumerable<SelectListItem> Services { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
