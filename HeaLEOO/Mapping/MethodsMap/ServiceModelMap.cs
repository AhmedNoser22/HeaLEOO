namespace HeaLEOO.Mapping
{
    public partial class MapProfile
    {
        public void ServiceModelMap()
        {
            CreateMap<ModelService, ServiceVM>()
                .ForMember(dest => dest.clinicId, opt => opt.MapFrom(src => src.ClinicId))
                .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.Clinic.Name))
                .ForMember(dest => dest.Clinics, opt => opt.Ignore());
            CreateMap<ServiceVM, ModelService>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Clinic, opt => opt.Ignore());
        }
    }
}
