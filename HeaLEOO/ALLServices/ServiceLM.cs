namespace HeaLEOO.ALLServices
{
    public class ServiceLM : IServiceLM
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






    }
}