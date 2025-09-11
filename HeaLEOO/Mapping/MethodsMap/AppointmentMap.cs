namespace HeaLEOO.Mapping
{
    public partial class MapProfile
    {
        public void AppointmentMap()
        {
            CreateMap<Appointments, AppointmentsVM>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctors.Name))
            .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status))
            .ForMember(dest => dest.isActive, opt => opt.MapFrom(src => src.isActive));
            CreateMap<AppointmentsVM, Appointments>();
        }
    }
}
