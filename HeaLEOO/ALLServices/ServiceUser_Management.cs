
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

        public Task<List<AppUserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AppUserDto?> GetUserByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
