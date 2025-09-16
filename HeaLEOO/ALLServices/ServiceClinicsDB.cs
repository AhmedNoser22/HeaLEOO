public class ServiceClinicsDB : IServiceClinicsDB
{
    private readonly IUnitOF_Work work;
    private readonly IMapper _mapper;
    private readonly ServiceImage _imageService;
    private readonly IServiceLookup _lookupService;

    public ServiceClinicsDB(
        IMapper mapper,
        ServiceImage imageService,
        IServiceLookup lookupService,
        IUnitOF_Work work)
    {
        _mapper = mapper;
        _imageService = imageService;
        _lookupService = lookupService;
        this.work = work;
    }

    public async Task<IEnumerable<ClinicVM>> GetAllClinicsAsync()
    {
        var clinics = await work.GetRepoCliinics.GetAll(include: query => query.Include(c => c.Services));
        var mapped = _mapper.Map<IEnumerable<ClinicVM>>(clinics);

        foreach (var c in mapped)
        {
            c.Appointments = _lookupService.GetAllAppointments();
        }
        return mapped;
    }

    public async Task<ClinicVM> GetClinicByIdAsync(int id)
    {
        var clinic = await work.GetRepoCliinics.GetById(id, query => query.Include(c => c.Services));
        if (clinic == null) return null!;

        var mapped = _mapper.Map<ClinicVM>(clinic);
        mapped.Appointments = _lookupService.GetAllAppointments();

        return mapped;
    }

    public async Task<ClinicVM> AddClinicAsync(ClinicVM clinicVM, IFormFile? file = null)
    {
        var clinic = _mapper.Map<Clinics>(clinicVM);
        if (file != null)
            clinic.PhotoUrl = await _imageService.UploadImageAsync(file);

        await work.GetRepoCliinics.Add(clinic);
        await work.Complete();

        return _mapper.Map<ClinicVM>(clinic);
    }

    public async Task<bool> DeleteClinicAsync(int id)
    {
        var clinic = await work.GetRepoCliinics.Delete(id);
        if (clinic == null) return false;

        if (!string.IsNullOrEmpty(clinic.PhotoUrl))
            _imageService.DeleteImage(clinic.PhotoUrl);

        return await work.Complete();
    }
}
