namespace HeaLEOO.Models
{
    public class Appointments
    {
        public int Id { get; set; }
        public DateTime App_Date { get; set; }
        public string? status { get; set; }
        public bool? isActive { get; set; }

    }
}
