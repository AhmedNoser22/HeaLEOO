namespace HeaLEOO.Models
{
    public class Doctors
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string phoneNumber { get; set; } = default!;
        public int specializationId { get; set; }
        public ICollection<ClinicDoctors> ClinicDoctors { get; set; } = new List<ClinicDoctors>();
        public Specializations specializations { get; set; } = default!;
        //Finished
    }
}
