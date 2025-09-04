using System.Linq.Expressions;

namespace HeaLEOO.Repository
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes);

        Task<T> GetById(int id);

        

        Task<T> Add(T entity);

        T Update(T entity);

        Task<T> Delete(int id);

        Task<bool> Complete();
    }
}
