namespace HeaLEOO.Mapping
{
    public partial class MapProfile
    {
        public void RegisterMap()
        {
            CreateMap<RegisterVM, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
