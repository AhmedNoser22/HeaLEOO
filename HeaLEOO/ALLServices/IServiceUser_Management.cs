namespace HeaLEOO.ALLServices
{
    public interface IServiceUser_Management
    {
        Task<List<AppUserDto>> GetAllUsersAsync();
        Task<AppUserDto?> GetUserByIdAsync(string userId);
        Task<bool> DeleteUserAsync(string userId);
    }
}
