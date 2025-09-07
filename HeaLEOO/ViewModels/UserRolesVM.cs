namespace HeaLEOO.ViewModels
{
    public class UserRolesVM
    {
        public string UserName { get; set; } = default!;
        public List<string> UserRoles { get; set; } = new();
        public List<string> AllRoles { get; set; } = new();
        public List<string> SelectedRoles { get; set; } = new();
    }

}
