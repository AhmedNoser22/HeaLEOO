namespace HeaLEOO.ALLServices
{
    public class ServiceLM : IServiceLM
    {
        private readonly IUnitOF_Work work;
        private readonly IMapper _mapper;
        private readonly IServiceClinDate _serviceClinDate;

        public ServiceLM(
            IMapper mapper,
            IServiceClinDate serviceClinDate,
            IUnitOF_Work work)
        {
            _mapper = mapper;
            _serviceClinDate = serviceClinDate;
            this.work = work;
        }

        public async Task<IEnumerable<ServiceVM>> GetAll()
        {
            var services = await work.GetRepoModelService.GetAll(query =>
                query.Include(x => x.Clinic));

            return _mapper.Map<IEnumerable<ServiceVM>>(services);
        }

        public async Task<ServiceVM?> GetById(int id)
        {
            var service = await work.GetRepoModelService.GetById(id);
            if (service == null) return null;

            var model = _mapper.Map<ServiceVM>(service);
            model.Clinics = _serviceClinDate.GetAllServiceClinDate();
            return model;
        }

        public async Task<bool> Create(ServiceVM model)
        {
            var entity = _mapper.Map<ModelService>(model);
            await work.GetRepoModelService.Add(entity);
            return await work.Complete();
        }

        public async Task<bool> Update(int id, ServiceVM model)
        {
            var entity = await work.GetRepoModelService.GetById(id);
            if (entity == null) return false;

            _mapper.Map(model, entity); 
            work.GetRepoModelService.Update(entity);
            return await work.Complete();
        }

        public async Task<bool> Delete(int id)
        {
            await work.GetRepoModelService.Delete(id);
            return await work.Complete();
        }
    }
}
