using VillaApi.Core.Contracts;
using VillaApi.Data;
using VillaApi.Models;

namespace VillaApi.Core.Repository
{
    public class VillaRepository : Repository<VillaM>, IVillaRepository
    {
        private readonly ApplicationContext _context;
        public VillaRepository(ApplicationContext context) : base(context)
        {
            _context = context; 
        }

        public async Task Update(VillaM villaM)
        {
            villaM.UpdatedDate = DateTime.Now;
            _context.Villas.Update(villaM); 
           await _context.SaveChangesAsync();
        }
    }
}
