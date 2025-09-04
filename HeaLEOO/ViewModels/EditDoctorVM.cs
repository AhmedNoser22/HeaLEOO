using Doctors_System.ViewModels;
namespace HeaLEOO.ViewModels
{
    public class EditDoctorVM : CreateDoctorVM
    {
        [Required]
        public int Id { get; set; }

        public string? CurrentImageUrl { get; set; }
    }
}
