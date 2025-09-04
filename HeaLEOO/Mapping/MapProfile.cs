using HeaLEOO.DTOs;

namespace HeaLEOO.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Doctors, DoctorsDto>();
        }
    }
}
