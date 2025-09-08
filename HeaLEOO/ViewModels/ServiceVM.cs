namespace HeaLEOO.ViewModels
{
    public class ServiceVM
    {
          public int Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public double Price { get; set; }
    }
}
