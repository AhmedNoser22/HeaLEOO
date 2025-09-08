public class RoleMvcController : Controller
{
    private readonly IRoleServices _roleService;

    public RoleMvcController(IRoleServices roleService)
    {
        _roleService = roleService;
    }

    public async Task<IActionResult> Index()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return View(roles);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        await _roleService.CreateRoleAsync(roleName);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteRole(string roleName)
    {
        await _roleService.DeleteRoleAsync(roleName);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> ManageUserRoles(string userName= "ahmednose32r")
    {
        var model = await _roleService.GetUserRolesAsync(userName);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUserRoles(UserRolesVM model)
    {
        await _roleService.UpdateUserRolesAsync(model);
        return RedirectToAction("Index");
    }
}
