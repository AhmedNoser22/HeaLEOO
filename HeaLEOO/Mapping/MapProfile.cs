namespace HeaLEOO.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<RegisterVM, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username));

        }
    }
}
