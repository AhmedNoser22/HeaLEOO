namespace HeaLEOO.ALLServices
{
    public class ServiceSpec: IServiceSpec
    {
        private readonly IUnitOF_Work work;
        private readonly IMapper _mapper;
        public ServiceSpec(IMapper mapper, IUnitOF_Work work)
        {
            _mapper = mapper;
            this.work = work;
        }
        public async Task<IEnumerable<SpecializationsVM>> GetSpecializations()
        {
            var specializations = await work.GetRepoSpecializations.GetAll();
            return _mapper.Map<IEnumerable<SpecializationsVM>>(specializations);
        }
        public async Task<SpecializationsVM> Addspecializations(SpecializationsVM specializations)
        {
            var spec = _mapper.Map<Specializations>(specializations);
            await work.GetRepoSpecializations.Add(spec);
            await work.Complete();
            return _mapper.Map<SpecializationsVM>(spec);

        }
    }
}
