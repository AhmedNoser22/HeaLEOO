namespace HeaLEOO.ViewModels
{
    public class ClinicFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        [AllowedAttribute(FileSetting.AllowedImageTypes)]
        [MaxSizeAttribute(FileSetting.MaxImageSize)]
        public IFormFile? Photo { get; set; } 
        public string? ExistingPhotoUrl { get; set; }
    }
}
