namespace HeaLEOO.ViewModels
{
    public class AppointmentsVM
    {
        public DateTime App_Date { get; set; }
        public string? status { get; set; }
        public bool? isActive { get; set; }
        [Display(Name = "Doctors")]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = default!;
        public IEnumerable<SelectListItem> SelectDoctors { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
