public class RoleMvcController : Controller
{
    private readonly IRoleService _roleService;

    public RoleMvcController(IRoleService roleService)
    {
        _roleService = roleService;
    }

}
