using System.Linq.Expressions;

namespace VillaApi.Core.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> expression,bool tracked= true, string? includePropeties = null); 
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>>? expression=null,string? includePropeties=null);
        Task Remove(T entity);
        Task Save();
    }
}
