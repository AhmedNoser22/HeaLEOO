namespace HeaLEOO.ALLServices
{
    public interface IServiceUserManagement
    {
        Task<List<AppUserDto>> GetAllUsersAsync();
        Task<AppUserDto?> GetUserByIdAsync(string userId);
        Task<bool> DeleteUserAsync(string userId);
    }
}
