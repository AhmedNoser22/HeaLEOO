using HeaLEOO.DTOs;

namespace HeaLEOO.ALLServices
{
    public interface IServiceUserManagement
    {
        Task<IEnumerable<AppUserDto>> GetAllUsersAsync();
        Task<AppUserDto?> GetUserByIdAsync(string userId);
        Task<bool> DeleteUserAsync(string userId);
    }
}
