using HeaLEOO.DTOs;

namespace HeaLEOO.ServicesHel
{
    public interface IAuthService
    {
        Task<AuthResult> RegisterAsync(RegisterDto dto);
        Task<AuthResult> LoginAsync(LoginDto dto);
        Task LogoutAsync();
    }
}
