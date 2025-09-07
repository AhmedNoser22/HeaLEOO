
namespace HeaLEOO.ALLServices
{
    public class ServiceUser_Management : IServiceUser_Management
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ServiceUser_Management(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Task<bool> DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppUserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<List<AppUserDto>>(users);
        }



        public Task<AppUserDto?> GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
