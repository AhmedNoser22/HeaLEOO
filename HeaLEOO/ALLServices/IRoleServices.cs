public interface IRoleServices
{
    public interface IRoleService
    {
        Task<List<UserManagerVM>> GetAllUsers();
        Task<List<RoleViewModel>> GetUserRoles(string userName);
        Task UpdateUserRoles(string userName, List<RoleViewModel> roles);
    }

}

