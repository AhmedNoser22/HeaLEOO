namespace HeaLEOO.Models
{
    public class Doctors
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string phoneNumber { get; set; } = default!;
        [ForeignKey("specializations")]
        public int specializationId { get; set; }
        public Specializations specializations { get; set; } = default!;
        public ICollection<ClinicDoctors> ClinicDoctors { get; set; } = new List<ClinicDoctors>();
        public ICollection<Appointments> Appointments { get; set; } = new List<Appointments>();
    }
}
