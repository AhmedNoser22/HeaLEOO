using System.Linq.Expressions;

namespace HeaLEOO.Repository
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? include = null);
        Task<T?> GetById(int id, Func<IQueryable<T>, IQueryable<T>>? include = null);
        Task<T> Add(T entity);
        T Update(T entity);
        Task<T> Delete(int id);
        Task<bool> Complete();
    }
}
