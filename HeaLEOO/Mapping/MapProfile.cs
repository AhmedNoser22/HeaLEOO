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
            UserManagementMap();
            CreateMap<RegisterVM,AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<AppUser, AppUserDto>();
            CreateMap<AppUserDto, AppUser>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));



        }
    }
}
