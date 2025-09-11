namespace HeaLEOO.ALLServices
{
    public interface IServiceAuth
    {

        Task<bool> RegisterAsync(RegisterVM register);
        Task<bool> LoginAsync(LoginVM login);
        Task<bool> Logout();
    }
}
