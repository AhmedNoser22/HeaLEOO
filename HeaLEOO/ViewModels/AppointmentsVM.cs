public class AppointmentsVM
{
    public int Id { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime App_Date { get; set; }

    public string? status { get; set; }
    public bool? isActive { get; set; }

    [Display(Name = "Doctors")]
    [Required]
    public int DoctorId { get; set; }
    public string? DoctorName { get; set; }

    [Display(Name = "Clinic")]
    [Required]
    public int ClinicId { get; set; }
    public string? ClinicName { get; set; }

    public AppUser? AppUser { get; set; }

    public IEnumerable<SelectListItem> SelectDoctors { get; set; } = Enumerable.Empty<SelectListItem>();
    public IEnumerable<SelectListItem> SelectClinics { get; set; } = Enumerable.Empty<SelectListItem>();
}
