namespace HeaLEOO.ALLServices
{
    public class ServiceLM: IServiceLM
    {
        private readonly AppDbContext _context;

        public ServiceLM(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceVM>> GetAllAsync()
        {
            return await _context.Services
                     .Select(s => new ServiceVM
                           {
                              Name = s.Name,
                              Price = s.Price
                           })
                     .ToListAsync();
        }

        public async Task<ServiceVM?> GetByIdAsync(int id)
        {
            var s = await _context.Services.FindAsync(id);
            if (s == null) return null;

            return new ServiceVM
            {
                Name = s.Name,
                Price = s.Price
            };
        }

        public async Task<ServiceVM> CreateAsync(ServiceVM vm)
        {
            var entity = new Services
            {
                Name = vm.Name,
                Price = vm.Price
            };

            _context.Services.Add(entity);
            await _context.SaveChangesAsync();

            return vm;
        }

        public async Task<bool> UpdateAsync(int id, ServiceVM vm)
        {
            var entity = await _context.Services.FindAsync(id);
            if (entity == null) return false;

            entity.Name = vm.Name;
            entity.Price = vm.Price;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Services.FindAsync(id);
            if (entity == null) return false;

            _context.Services.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

