using System.Linq.Expressions;

namespace VillaApi.Core.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> expression,bool tracked= true); 
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>>? expression=null);
        Task Remove(T entity);
        Task Save();
    }
}
