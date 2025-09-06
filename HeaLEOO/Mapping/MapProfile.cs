namespace HeaLEOO.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // controllers
            // user management
            // roles

            CreateMap<Doctors, DoctorViewModel>()
           .ForMember(dest => dest.SpecializationName, opt => opt.MapFrom(src => src.specializations.Name))
           .ForMember(dest => dest.SpecializationId, opt => opt.MapFrom(src => src.specializationId))
           .ForMember(dest => dest.ClinicIds, opt => opt.MapFrom(src => src.ClinicDoctors.Select(cd => cd.ClinicId)))
           .ForMember(dest => dest.ClinicNames, opt => opt.MapFrom(src => src.ClinicDoctors.Select(cd => cd.Clinic.Name)))
           .ForMember(dest => dest.Specializations, opt => opt.Ignore())
           .ForMember(dest => dest.Clinics, opt => opt.Ignore());
            CreateMap<DoctorViewModel, Doctors>()
           .ForMember(dest => dest.ClinicDoctors, opt => opt.Ignore())
              .ForMember(dest => dest.specializations, opt => opt.Ignore());
            CreateMap<SpecializationsVM, Specializations>();
            CreateMap<Specializations, SpecializationsVM>();
            CreateMap<ClinicVM, Clinics>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Clinics, ClinicVM>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.PhotoUrl));
            CreateMap<ClinicFormVM, Clinics>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.Ignore());
            CreateMap<Clinics, ClinicFormVM>()
                .ForMember(dest => dest.Photo, opt => opt.Ignore());
            CreateMap<RegisterVM,AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)); ;
            CreateMap<Appointments, AppointmentsVM>();
            CreateMap<AppointmentsVM, Appointments>();
            CreateMap<Services, ServiceVM>();
            CreateMap<ServiceVM, Services>();


        }
    }
}
