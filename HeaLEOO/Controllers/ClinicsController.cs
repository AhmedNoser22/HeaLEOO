public class ClinicsController : Controller
{
    private readonly IServiceClinicsDB _serviceClinics;
    private readonly IMapper _mapper;

    public ClinicsController(IServiceClinicsDB serviceClinics, IMapper mapper)
    {
        _serviceClinics = serviceClinics;
        _mapper = mapper;
    }


}
