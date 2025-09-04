using HeaLEOO.DTOs;

namespace HeaLEOO.ServicesHel
{
 
    
        public class AuthService : IAuthService
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly ILogger<AuthService> _logger;

            public AuthService(UserManager<AppUser> userManager,
                               SignInManager<AppUser> signInManager,
                               ILogger<AuthService> logger)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _logger = logger;
            }

        
            public async Task<AuthResult> RegisterAsync(RegisterDto dto)
            {
                 if (dto.Password != dto.ConfirmPassword)
               {
                return new AuthResult
                {
                    Succeeded = false,
                    Errors = new[] { "Passwords do not match." }
                };
               }

            var existing = await _userManager.FindByEmailAsync(dto.Email);
                if (existing != null)
                {
                    return new AuthResult
                    {
                        Succeeded = false,
                        Errors = new[] { "Email is already in use." }
                    };
                }

   
                var user = new AppUser
                {
                    UserName = dto.Email,   
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    PhoneNumber = dto.PhoneNumber,
                    Age = dto.Age,
                    Gender = dto.Gender,
                    Country = dto.Country
                };

                var createResult = await _userManager.CreateAsync(user, dto.Password);
                if (!createResult.Succeeded)
                {
                    return new AuthResult
                    {
                        Succeeded = false,
                        Errors = createResult.Errors.Select(e => e.Description)
                    };
                }

             
                await _signInManager.SignInAsync(user, isPersistent: false);

                _logger.LogInformation("New user registered: {Email}", dto.Email);

                return new AuthResult { Succeeded = true };
            }

          
            public async Task<AuthResult> LoginAsync(LoginDto dto)
            {
       
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user == null)
                {
                    return new AuthResult
                    {
                        Succeeded = false,
                        Errors = new[] { "Invalid login attempt." }
                    };
                }

              
                var result = await _signInManager.PasswordSignInAsync(user.UserName, dto.Password, dto.RememberMe, lockoutOnFailure: false);
                if (!result.Succeeded)
                {
                
                    return new AuthResult
                    {
                        Succeeded = false,
                        Errors = new[] { "Invalid login attempt." }
                    };
                }

                return new AuthResult { Succeeded = true };
            }

          
            public async Task LogoutAsync()
            {
                await _signInManager.SignOutAsync();
            }
        }
    
}
