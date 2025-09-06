namespace HeaLEOO.ALLServices
{
    public interface IServiceUserManagement
    {
        Task<List<AppUser>> GetAllUsersAsync();
        Task<AppUser?> GetUserByIdAsync(string userId);
        Task<bool> CreateUserAsync(string email, string password, string role);
        Task<bool> UpdateUserEmailAsync(string userId, string newEmail);
        Task<bool> DeleteUserAsync(string userId);
        Task<bool> AssignRoleAsync(string userId, string role);
    }
}
