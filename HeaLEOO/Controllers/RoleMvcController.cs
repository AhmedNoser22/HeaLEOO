public class RoleMvcController : Controller
{
    private readonly IRoleService _roleService;

    public RoleMvcController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<IActionResult> Users()
    {
        var users = await _roleService.GetAllUsers();
        return View(users);
    }

    public async Task<IActionResult> ManageUserRoles(string userName)
    {
        var model = await _roleService.GetUserRoles(userName);
        ViewBag.UserName = userName;
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ManageUserRoles(string userName, List<RoleViewModel> model)
    {
        if (!ModelState.IsValid) return View(model);

        await _roleService.UpdateUserRoles(userName, model);
        return RedirectToAction(nameof(Users));
    }
    public IActionResult CreateRole()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
        {
            TempData["Error"] = "Role name is required.";
            return View();
        }

        var result = await _roleService.CreateRoleAsync(roleName);

        if (result.Succeeded)
        {
            TempData["Success"] = "Role created successfully.";
            return RedirectToAction(nameof(Users));
        }

        TempData["Error"] = string.Join(", ", result.Errors.Select(e => e.Description));
        return View();
    }

}
