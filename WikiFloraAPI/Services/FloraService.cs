using Microsoft.EntityFrameworkCore;
using WikiFloraAPI.Data;
using WikiFloraAPI.Models;

namespace WikiFloraAPI.Services
{
    public class FloraService : IFloraService
    {
        private readonly DataContext _context;

        public FloraService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Flora?>> GetFloraList()
        {
            return await _context.Floras.Include(flora => flora.ScientificName).ToListAsync<Flora?>();
        }

      public async Task<Flora> AddFlora(Flora flora)
        {
          _context.Add(flora);
          await _context.SaveChangesAsync();
          return flora;
        }

       public async Task<Flora> GetSingleFlora()
        {
            throw new NotImplementedException();
        }
    }
}
