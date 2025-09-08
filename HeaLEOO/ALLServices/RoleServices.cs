using static IRoleServices;
public class RoleService : IRoleService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<List<UserManagerVM>> GetAllUsers()
    {
        return _userManager.Users.Select(u => new UserManagerVM
        {
            Id = u.Id,
            UserName = u.UserName!,
            Email = u.Email!
        }).ToList();
    }

    public async Task<List<RoleViewModel>> GetUserRoles(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        var roles = _roleManager.Roles.ToList();

        var model = new List<RoleViewModel>();
        foreach (var role in roles)
        {
            model.Add(new RoleViewModel
            {
                RoleName = role.Name!,
                IsSelected = await _userManager.IsInRoleAsync(user!, role.Name!)
            });
        }
        return model;
    }

    public async Task UpdateUserRoles(string userName, List<RoleViewModel> roles)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null) return;
        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);
        var selectedRoles = roles.Where(r => r.IsSelected).Select(r => r.RoleName);
        await _userManager.AddToRolesAsync(user, selectedRoles);
    }
}
