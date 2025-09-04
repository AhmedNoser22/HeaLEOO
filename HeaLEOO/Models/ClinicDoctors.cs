namespace HeaLEOO.Models
{
    public class ClinicDoctors
    {
        //Test MME
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
        public Doctors Doctor { get; set; } = default!;
        public Clinics Clinic { get; set; } = default!;
    }
}
