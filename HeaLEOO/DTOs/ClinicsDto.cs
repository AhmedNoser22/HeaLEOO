namespace HeaLEOO.DTOs
{
    public class ClinicsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? PhotoUrl { get; set; }

        public List<int> DoctorIds { get; set; } = new List<int>();

    }
}
