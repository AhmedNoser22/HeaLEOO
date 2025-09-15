namespace HeaLEOO.Models
{
    public class Doctors
    {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string phoneNumber { get; set; } = default!;

            public int SpecializationId { get; set; }   

            public ICollection<ClinicDoctors> ClinicDoctors { get; set; } = new List<ClinicDoctors>();

            public Specializations Specialization { get; set; } = default!;  

    }
}
