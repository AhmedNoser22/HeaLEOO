namespace HeaLEOO.ServicesHel
{
    public class ServiceAuth : IServiceAuth
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public ServiceAuth(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task<bool> RegisterAsync(RegisterVM register)
        {
            var existingEmail = await _userManager.FindByEmailAsync(register.Email);
            if (existingEmail != null)
                return false;

            var registerUser = _mapper.Map<AppUser>(register);
            var result = await _userManager.CreateAsync(registerUser, register.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(registerUser, isPersistent: false);
                await _userManager.AddToRoleAsync(registerUser, "Patient");
                return true;
            }
            return false;
        }
        public async Task<bool> LoginAsync(LoginVM login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
                return false;

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<bool> Logout()
        {
            await _signInManager.SignOutAsync();
            return true;
        }
    }
}
