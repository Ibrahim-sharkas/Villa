using VillaApi.Core.Contracts;
using VillaApi.Data;
using VillaApi.Models;

namespace VillaApi.Core.Repository
{
    public class VillaNumRepository : Repository<VillaNumber>, IVillaNumRepository
    {
        private ApplicationContext _context;
        public VillaNumRepository(ApplicationContext context) : base(context)
        {
            _context = context; 
        }

        public async Task Update(VillaNumber number)
        {
            number.UpdatedDate=DateTime.Now;
            _context.Update(number);
            await _context.SaveChangesAsync();
        }
    }
}
