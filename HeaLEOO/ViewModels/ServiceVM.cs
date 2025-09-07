namespace HeaLEOO.ViewModels
{
    public class ServiceVM
    {
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public double Price { get; set; }
    }
}
