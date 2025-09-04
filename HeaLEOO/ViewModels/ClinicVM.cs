namespace HeaLEOO.ViewModels
{
    public class ClinicVM
    {
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        [AllowedAttribute(FileSetting.AllowedImageTypes),MaxSizeAttribute(FileSetting.MaxImageSize)]
        public string? PhotoUrl { get; set; }
        
    }
}
