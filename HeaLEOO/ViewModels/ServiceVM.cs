namespace HeaLEOO.ViewModels
{
    public class ServiceVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public double Price { get; set; }
        [Display(Name = "Clinics")]
        [Required(ErrorMessage = "clinic is required.")]
        public int clinicId { get; set; }
        public IEnumerable<SelectListItem> Clinics { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
