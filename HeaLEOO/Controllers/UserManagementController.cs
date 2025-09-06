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
            var model = _mapper.Map<List<AppUserDto>>(users);
            return View(model);
        }
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _serviceUserManagement.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            var model = _mapper.Map<AppUserDto>(user);
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _serviceUserManagement.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            var model = _mapper.Map<AppUserDto>(user);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var result = await _serviceUserManagement.DeleteUserAsync(id);

            if (result)
                TempData["Success"] = "✅ User deleted successfully.";
            else
                TempData["Error"] = "❌ Failed to delete user.";

            return RedirectToAction(nameof(Index));
        }
    }
}
