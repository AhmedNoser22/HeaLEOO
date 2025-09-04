namespace HeaLEOO.DTOs
{
    public class RegisterDto
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }   
        public string PhoneNumber { get; set; }  
        public int? Age { get; set; }          
        public string Gender { get; set; }     
        public string Country { get; set; }   
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
