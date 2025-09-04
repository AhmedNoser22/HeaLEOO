namespace HeaLEOO.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
            /// helo world ............
            ///  fiiiiiiiiiiiiiiooood
        }
        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Complete()
        {
            throw new NotImplementedException();
        }
        
    }
}
