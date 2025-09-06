namespace HeaLEOO.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IServiceUserManagement _serviceUserManagement;

        public UserManagementController(IServiceUserManagement serviceUserManagement)
        {
            _serviceUserManagement = serviceUserManagement;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _serviceUserManagement.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _serviceUserManagement.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var result = await _serviceUserManagement.DeleteUserAsync(id);

            TempData[result ? "Success" : "Error"] =
                result ? "✅ User deleted successfully." : "❌ Failed to delete user.";

            return RedirectToAction(nameof(Index));
        }

    }
}