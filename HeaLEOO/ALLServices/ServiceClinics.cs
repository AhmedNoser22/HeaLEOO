namespace HeaLEOO.ALLServices
{
    public class ServiceClinics: IServiceClinics
    {
        private readonly IGenericRepo<Clinics> _repo;
        private readonly IMapper _mapper;
        private readonly ImageService _imageService;

        public ServiceClinics(IGenericRepo<Clinics> repo, IMapper mapper, ImageService imageService)
        {
            _repo = repo;
            _mapper = mapper;
            _imageService = imageService;
        }
        public async Task<ClinicVM> AddClinicAsync(ClinicVM clinicVM, IFormFile? file = null)
        {
            var clinic = _mapper.Map<Clinics>(clinicVM);
            //file upload
            if (file != null)
            {
                clinic.PhotoUrl = await _imageService.UploadImageAsync(file);
            }

            await _repo.Add(clinic);
            await _repo.Complete();

            return _mapper.Map<ClinicVM>(clinic);
        }
        public async Task<IEnumerable<ClinicVM>> GetAllClinicsAsync()
        {
            var clinics = await _repo.GetAll();
            return _mapper.Map<IEnumerable<ClinicVM>>(clinics);
        }
        public async Task<ClinicVM> GetClinicByIdAsync(int id)
        {
            var clinic = await _repo.GetById(id);
            return _mapper.Map<ClinicVM>(clinic);
        }
        public async Task<bool> DeleteClinicAsync(int id)
        {
            var clinic = await _repo.Delete(id);
            if (!string.IsNullOrEmpty(clinic.PhotoUrl))
                _imageService.DeleteImage(clinic.PhotoUrl);

            return await _repo.Complete();
        }
    }
}
