namespace HeaLEOO.ALLServices
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<List<UserManagerVM>> GetAllUsers()
        {
            return await _userManager.Users
                .Select(u => new UserManagerVM
                {
                    Id = u.Id,
                    UserName = u.UserName!,
                    Email = u.Email!
                })
                .ToListAsync();
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
        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return IdentityResult.Failed(new IdentityError { Description = "Role name cannot be empty" });

            if (await _roleManager.RoleExistsAsync(roleName))
                return IdentityResult.Failed(new IdentityError { Description = "Role already exists" });

            var role = new IdentityRole(roleName);
            return await _roleManager.CreateAsync(role);
        }

    }
}