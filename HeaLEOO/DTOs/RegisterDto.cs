﻿namespace HeaLEOO.DTOs
{
    public class RegisterDto
    {
        public string UserName { get; set; } = default!; 
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
