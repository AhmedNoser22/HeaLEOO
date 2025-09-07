namespace HeaLEOO.ALLServices
{
    public class ServiceUserManagement : IServiceUserManagement
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ServiceUserManagement(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<AppUserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<List<AppUserDto>>(users);
        }

        public async Task<AppUserDto?> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user == null ? null : _mapper.Map<AppUserDto>(user);
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}