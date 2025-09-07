namespace TestApiCore.Services
{
    public class RoleService:IRoleServices
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<List<RoleViewModel>> GetAllRolesAsync()
        {
            return await _roleManager.Roles
                        .Select(r => new RoleViewModel { RoleName = r.Name! })
                        .ToListAsync();
        }
        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
                return IdentityResult.Failed(new IdentityError { Description = "Role already exists." });

            var role = new IdentityRole(roleName);
            return await _roleManager.CreateAsync(role);
        }

        public async Task<IdentityResult> DeleteRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
                return IdentityResult.Failed(new IdentityError { Description = "Role not found." });

            return await _roleManager.DeleteAsync(role);
        }
        public async Task<UserRolesVM> GetUserRolesAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return new UserRolesVM { UserName = userName, AllRoles = new List<string>(), UserRoles = new List<string>() };

            var allRoles = await _roleManager.Roles.Select(r => r.Name!).ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);

            return new UserRolesVM
            {
                UserName = userName,
                AllRoles = allRoles,
                UserRoles = userRoles.ToList()
            };
        }
        public async Task UpdateUserRolesAsync(UserRolesVM model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null) return;

            var currentRoles = await _userManager.GetRolesAsync(user);
            var rolesToRemove = currentRoles.Except(model.SelectedRoles ?? new List<string>());
            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
            var rolesToAdd = (model.SelectedRoles ?? new List<string>()).Except(currentRoles);
            await _userManager.AddToRolesAsync(user, rolesToAdd);
        }
    }
}
