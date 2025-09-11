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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClinicVM model, IFormFile file)
    {
        if (!ModelState.IsValid) return View(model);

        await _serviceClinics.AddClinicAsync(model, file);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var success = await _serviceClinics.DeleteClinicAsync(id);
        if (!success) return NotFound();

        return RedirectToAction(nameof(Index));
    }



}
