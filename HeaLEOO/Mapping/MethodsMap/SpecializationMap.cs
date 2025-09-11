namespace HeaLEOO.Mapping
{
    public partial class MapProfile
    {
        public void SpecializationMap()
        {
            CreateMap<SpecializationsVM, Specializations>();
            CreateMap<Specializations, SpecializationsVM>();
        }
    }
}
