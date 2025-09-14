namespace HeaLEOO.Models
{
    public class ClinicDoctors
    {
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
        public Clinics Clinic { get; set; } = default!;

    }
}
