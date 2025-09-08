namespace HeaLEOO.ViewModels
{
    public class UserManagerVM
    {
        public string Id { get; set; } = string.Empty;
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; } = string.Empty;
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;
    }
}
