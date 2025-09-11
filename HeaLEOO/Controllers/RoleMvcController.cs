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




}
