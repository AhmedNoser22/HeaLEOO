namespace HeaLEOO.ALLServices
{
    public interface IRoleServices
    {
        Task<List<RoleViewModel>> GetAllRolesAsync();
        Task<IdentityResult> CreateRoleAsync(string roleName);
        Task<IdentityResult> DeleteRoleAsync(string roleName);
        Task<UserRolesVM> GetUserRolesAsync(string userName);
        Task UpdateUserRolesAsync(UserRolesVM model);
    }
}
