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


}
