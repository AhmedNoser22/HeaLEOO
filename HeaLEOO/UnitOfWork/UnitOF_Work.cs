namespace HeaLEOO.UnitOfWork
{
    public class UnitOF_Work : IUnitOF_Work
    {
        private readonly AppDbContext _context;
        public IGenericRepo<Clinics> GetRepoCliinics { get; private set; }
        public IGenericRepo<Doctors> GetRepoDoctors { get; private set; }

        public IGenericRepo<Appointments> GetRepoAppointments { get; private set; }

        public IGenericRepo<ModelService> GetRepoModelService { get; private set; }

        public IGenericRepo<Specializations> GetRepoSpecializations { get; private set; }
        public UnitOF_Work(AppDbContext context)
        {
            _context = context;
            GetRepoCliinics = new GenericRepo<Clinics>(_context);
            GetRepoDoctors = new GenericRepo<Doctors>(_context);
            GetRepoAppointments = new GenericRepo<Appointments>(_context);
            GetRepoModelService = new GenericRepo<ModelService>(_context);
            GetRepoSpecializations = new GenericRepo<Specializations>(_context);
        }
        public async Task<bool> Complete() => await _context.SaveChangesAsync() > 0;
        public void Dispose() => _context.Dispose();
    }
}
