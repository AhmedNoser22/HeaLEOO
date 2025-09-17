namespace HeaLEOO.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _Context;

        public GenericRepo(AppDbContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null,Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            IQueryable<T> query = _Context.Set<T>();

            if (filter != null)
                query = query.Where(filter);
            if (include != null)
                query = include(query);

            return await query.ToListAsync();
        }
        public async Task<T?> GetById(int id, Func<IQueryable<T>, IQueryable<T>>? include = null)
        {
            IQueryable<T> query =_Context.Set<T>();

            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }
        public async Task<T> Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

            await _Context.Set<T>().AddAsync(entity);
            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

            _Context.Set<T>().Update(entity);
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be greater than zero", nameof(id));
            var entity = await _Context.Set<T>().FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with id {id} was not found");

            _Context.Set<T>().Remove(entity);
            return entity;
        }


    }
}
