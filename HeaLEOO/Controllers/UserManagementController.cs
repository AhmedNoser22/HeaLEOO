using Microsoft.AspNetCore.Mvc;

namespace HeaLEOO.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IServiceUserManagement _serviceUserManagement;
        private readonly IMapper _mapper;

        public UserManagementController(IServiceUserManagement serviceUserManagement, IMapper mapper)
        {
            _serviceUserManagement = serviceUserManagement;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _serviceUserManagement.GetAllUsersAsync();
            var model = _mapper.Map<List<UserManagerVM>>(users);
            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var user = await _serviceUserManagement.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            var model = _mapper.Map<UserManagerVM>(user);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string email, string password, string role)
        {
            if (!ModelState.IsValid) return View();

            var result = await _serviceUserManagement.CreateUserAsync(email, password, role);
            if (!result) return View();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var user = await _serviceUserManagement.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            var model = _mapper.Map<UserManagerVM>(user);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserManagerVM model, string newEmail)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _serviceUserManagement.UpdateUserEmailAsync(model.Id, newEmail);
            if (!result) return View(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var user = await _serviceUserManagement.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            var model = _mapper.Map<UserManagerVM>(user);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _serviceUserManagement.DeleteUserAsync(id);
            if (result) TempData["Success"] = "User deleted successfully.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            var result = await _serviceUserManagement.AssignRoleAsync(userId, role);
            if (result) TempData["Success"] = "Role assigned successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
