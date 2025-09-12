namespace HeaLEOO.ViewModels
{
    public class ClinicVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? PhotoUrl { get; set; }
        public int AppointmentId { get; set; }
        public IEnumerable<SelectListItem> Appointments { get; set; } = Enumerable.Empty<SelectListItem>();
        public int ServiceId { get; set; }
        public List<string> ServiceNames { get; set; } = new();
    }
}
