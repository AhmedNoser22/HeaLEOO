public class ServiceClinicsDB : IServiceClinicsDB
{
    private readonly IGenericRepo<Clinics> _repo;
    private readonly IMapper _mapper;
    private readonly IServiceImage _imageService;
    private readonly IServiceNserv _serviceNserv;
    private readonly IServiceLookup _lookupService;

    public ServiceClinicsDB(
        IGenericRepo<Clinics> repo,
        IMapper mapper,
        IServiceImage imageService,
        IServiceNserv serviceNserv,
        IServiceLookup lookupService)
    {
        _repo = repo;
        _mapper = mapper;
        _imageService = imageService;
        _serviceNserv = serviceNserv;
        _lookupService = lookupService;
    }
    public async Task<IEnumerable<ClinicVM>> GetAllClinicsAsync()
    {
        var clinics = await _repo.GetAll();
        var mapped = _mapper.Map<IEnumerable<ClinicVM>>(clinics);

        foreach (var c in mapped)
        {
            c.Appointments = _lookupService.GetAllAppointments();
            c.Services = _serviceNserv.GetAllServices();
        }

        return mapped;
    }

    public async Task<ClinicVM> GetClinicByIdAsync(int id)
    {
        var clinic = await _repo.GetById(id);
        if (clinic == null) return null;

        var mapped = _mapper.Map<ClinicVM>(clinic);
        mapped.Appointments = _lookupService.GetAllAppointments();
        mapped.Services = _serviceNserv.GetAllServices();

        return mapped;
    }

    public async Task<ClinicVM> AddClinicAsync(ClinicVM clinicVM, IFormFile? file = null)
    {
        var clinic = _mapper.Map<Clinics>(clinicVM);
        if (file != null)
            clinic.PhotoUrl = await _imageService.UploadImageAsync(file);

        await _repo.Add(clinic);
        await _repo.Complete();

        return _mapper.Map<ClinicVM>(clinic);
    }
    public async Task<bool> DeleteClinicAsync(int id)
    {
        var clinic = await _repo.Delete(id);
        if (clinic == null) return false;

        if (!string.IsNullOrEmpty(clinic.PhotoUrl))
            _imageService.DeleteImage(clinic.PhotoUrl);

        return await _repo.Complete();
    }
}
