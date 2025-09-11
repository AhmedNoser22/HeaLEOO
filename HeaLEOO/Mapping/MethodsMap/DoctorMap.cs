namespace HeaLEOO.Mapping
{
    public partial class MapProfile
    {
        public void DoctorMap()
        {
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

        }
    }
}
