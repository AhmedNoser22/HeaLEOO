using HeaLEOO.DTOs;

namespace HeaLEOO.Mapping
{
    public partial class MapProfile : Profile
    {
        public MapProfile()
        {
            DoctorMap();
            SpecializationMap();
            ClinicMap();
            ServiceModelMap();
            AppointmentMap();
            CreateMap<RegisterVM,AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserDto, AppUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<AppUser, UserManagerVM>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<UserManagerVM, AppUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));



        }
    }
}
