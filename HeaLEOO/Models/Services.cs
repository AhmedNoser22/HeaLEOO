namespace HeaLEOO.Models
{
    public class Services
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public double Price { get; set; }
        [ForeignKey("Clinic")]
        public int ClinicId { get; set; }
        public Clinics Clinic { get; set; } = default!;
    }
}
