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
            RegisterMap();
            AppUserMap();
        }
    }
}
