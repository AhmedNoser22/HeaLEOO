namespace HeaLEOO.Mapping
{
    public partial class MapProfile
    {
        public void ClinicMap()
        {
            CreateMap<Clinics, ClinicVM>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.PhotoUrl))
                .ForMember(dest => dest.ServiceNames, opt => opt.MapFrom(src => src.Services.Select(s => s.Name)));
            CreateMap<ClinicVM, Clinics>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ClinicFormVM, Clinics>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.Ignore());
            CreateMap<Clinics, ClinicFormVM>()
                .ForMember(dest => dest.Photo, opt => opt.Ignore());
        }
    }
}
