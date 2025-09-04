namespace HeaLEOO.DTOs
{
    public class DoctorsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string phoneNumber { get; set; } = default!;
        [ForeignKey("specializations")]
        public int specializationId { get; set; }
    }
}
