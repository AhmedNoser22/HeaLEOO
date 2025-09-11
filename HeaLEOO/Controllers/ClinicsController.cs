public class ClinicsController : Controller
{
    private readonly IServiceClinicsDB _serviceClinics;
    private readonly IMapper _mapper;

    public ClinicsController(IServiceClinicsDB serviceClinics, IMapper mapper)
    {
        _serviceClinics = serviceClinics;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var clinics = await _serviceClinics.GetAllClinicsAsync();
        return View(clinics);
    }

    public async Task<IActionResult> Details(int id)
    {
        var clinic = await _serviceClinics.GetClinicByIdAsync(id);
        if (clinic == null) return NotFound();

        return View(clinic);
    }

    public IActionResult Create()
    {
        return View();
    }





}
