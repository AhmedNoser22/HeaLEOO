namespace HeaLEOO.ALLServices
{
    public interface IRoleService
    {
        
            IEnumerable<IdentityRole> GetRoles();
            Task<IdentityRole> CreateRoleAsync(IdentityRole role);
            Task<IEnumerable<UserManagerVM>> GetRolesAsync(string id);
            Task<IdentityResult> AddUserToRoleAsync(List<UserManagerVM> managerVMs, string id);
        
    }
}
