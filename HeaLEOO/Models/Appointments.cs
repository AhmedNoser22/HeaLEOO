namespace HeaLEOO.Models
{
    public class Appointments
    {
        public int Id { get; set; }
        public DateTime App_Date { get; set; }
        public string? status { get; set; }
        public bool? isActive { get; set; }
        [ForeignKey("Doctors")]
        public int DoctorId { get; set; }
        [ForeignKey("Clinics")]
        public int ClinicId { get; set; }
        public Doctors Doctors { get; set; } = default!;
        public Clinics Clinics { get; set; } = default!;
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; } = default!;
        public AppUser AppUser { get; set; } = default!;

    }
}
