using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HeaLEOO.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var roles = _roleService.GetRoles();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                await _roleService.CreateRoleAsync(model);
                TempData["SuccessMessage"] = "Role created successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to create role: {ex.Message}";
                return View(model);
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            var usersInRole = await _roleService.GetRolesAsync(id);
            if (usersInRole == null) return NotFound();

            return View(usersInRole); 
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var usersInRole = await _roleService.GetRolesAsync(id);
            if (usersInRole == null) return NotFound();

            return View(usersInRole); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, List<UserManagerVM> model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _roleService.AddUserToRoleAsync(model, id);
            if (!result.Succeeded)
            {
                TempData["ErrorMessage"] = "Failed to update role assignments.";
                return View(model);
            }

            TempData["SuccessMessage"] = "Role assignments updated successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
