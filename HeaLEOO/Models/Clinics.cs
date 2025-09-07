namespace HeaLEOO.Models
{
    public class Clinics
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? PhotoUrl { get; set; }
        public ICollection<ClinicDoctors> ClinicDoctors { get; set; } = new List<ClinicDoctors>();
        public ICollection<ModelService> Services { get; set; } = new List<ModelService>();
        public ICollection<Appointments> Appointments { get; set; } = new List<Appointments>();
    }
}
