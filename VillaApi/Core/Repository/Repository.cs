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
            //_context.VillaNumbers.Include(i => i.Villa).ToList(); this code to see how to get  prop in table that match prop sepcified
            dbset = _context.Set<T>();  
        }

        public async Task CreateAsync(T entity)
        {
            dbset.Add(entity);
            await Save();

        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression= null, string? includePropeties = null)
        {

            IQueryable<T> query = dbset;
            if (expression!=null)
            {
                query = query.Where(expression);    
            }
            if (includePropeties != null)
            {
                foreach (var item in includePropeties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, bool tracked = true, string? includePropeties = null)
        {
            IQueryable<T> query = dbset;
            if (!tracked)
            {
                query = query.AsNoTracking(); 
            }
            if (includePropeties != null)
            {
                foreach (var item in includePropeties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
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
