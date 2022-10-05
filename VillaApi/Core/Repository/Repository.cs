using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VillaApi.Core.Contracts;
using VillaApi.Data;

namespace VillaApi.Core.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _context;// represents the database
        internal DbSet<T> dbset;// represents the table in the database 
        public Repository(ApplicationContext context)
        {
            _context = context;
            dbset = _context.Set<T>();  
        }

        public async Task CreateAsync(T entity)
        {
            dbset.Add(entity);
            await Save();

        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression= null)
        {

            IQueryable<T> query = dbset;
            if (expression!=null)
            {
                query = query.Where(expression);    
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool tracked = true)
        {
            IQueryable<T> query = dbset;
            if (!tracked)
            {
                query = query.AsNoTracking(); 
            }
            query = query.Where(expression);    
            return await query.FirstOrDefaultAsync();
        }

        public async Task Remove(T entity)
        {
            dbset.Remove(entity);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
