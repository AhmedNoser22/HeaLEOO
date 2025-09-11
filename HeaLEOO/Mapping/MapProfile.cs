using HeaLEOO.DTOs;

namespace HeaLEOO.Mapping
{
    public partial class MapProfile : Profile
    {
        public MapProfile()
        {
            DoctorMap();
            SpecializationMap();
            CreateMap<Clinics, ClinicVM>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.PhotoUrl))
                .ForMember(dest => dest.ServiceNames, opt => opt.MapFrom(src => src.Services.Select(s => s.Name)));
           CreateMap<ClinicVM, Clinics>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ClinicFormVM, Clinics>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.Ignore());
            CreateMap<Clinics, ClinicFormVM>()
                .ForMember(dest => dest.Photo, opt => opt.Ignore());
            CreateMap<RegisterVM,AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
            CreateMap<Appointments, AppointmentsVM>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctors.Name))
            .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status))
            .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => src.isActive));
            CreateMap<AppointmentsVM, Appointments>();
            CreateMap<ModelService, ServiceVM>()
                .ForMember(dest => dest.clinicId, opt => opt.MapFrom(src => src.ClinicId))
                .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.Clinic.Name))
                .ForMember(dest => dest.Clinics, opt => opt.Ignore());
            CreateMap<ServiceVM, ModelService>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Clinic, opt => opt.Ignore());
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
