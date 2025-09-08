namespace HeaLEOO.ALLServices
{
    public class ServiceLM : IServiceLM
    {
        private readonly IGenericRepo<ModelService> _genericRepo;
        private readonly IMapper _mapper;
        private readonly IServiceClinDate _serviceClinDate;

        public ServiceLM(
            IGenericRepo<ModelService> genericRepo,
            IMapper mapper,
            IServiceClinDate serviceClinDate)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
            _serviceClinDate = serviceClinDate;
        }

        public async Task<IEnumerable<ServiceVM>> GetAll()
        {
            var services = await _genericRepo.GetAll(query =>
                query.Include(x => x.Clinic));

            return _mapper.Map<IEnumerable<ServiceVM>>(services);
        }

        public async Task<ServiceVM?> GetById(int id)
        {
            var service = await _genericRepo.GetById(id);
            if (service == null) return null;

            var model = _mapper.Map<ServiceVM>(service);
            model.Clinics = _serviceClinDate.GetAllServiceClinDate();
            return model;
        }

        public async Task<bool> Create(ServiceVM model)
        {
            var entity = _mapper.Map<ModelService>(model);
            await _genericRepo.Add(entity);
            return await _genericRepo.Complete();
        }

        public async Task<bool> Update(int id, ServiceVM model)
        {
            var entity = await _genericRepo.GetById(id);
            if (entity == null) return false;

            _mapper.Map(model, entity); 
            _genericRepo.Update(entity);
            return await _genericRepo.Complete();
        }

        public async Task<bool> Delete(int id)
        {
            await _genericRepo.Delete(id);
            return await _genericRepo.Complete();
        }
    }
}
