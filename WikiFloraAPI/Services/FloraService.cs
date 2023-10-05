using Microsoft.EntityFrameworkCore;
using WikiFloraAPI.Data;
using WikiFloraAPI.Models;

namespace WikiFloraAPI.Services
{

    public class FloraService : IFloraService
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;

        public FloraService(DataContext context,IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        private int _GetBanglaAlphabetIndex(string BanglaName)
        {
            List<char> banglaAlphabetUnicodeChars = new List<char>()
        {
            '\u0985', // অ
            '\u0986', // আ
            '\u0987', // ই
            '\u0988', // ঈ
            '\u0989', // উ
            '\u098A', // ঊ
            '\u098B', // ঋ
            '\u098F', // এ
            '\u0990', // ঐ
            '\u0993', // ও
            '\u0994', // ঔ
            '\u0995', // ক
            '\u0996', // খ
            '\u0997', // গ
            '\u0998', // ঘ
            '\u0999', // ঙ
            '\u099A', // চ
            '\u099B', // ছ
            '\u099C', // জ
            '\u099D', // ঝ
            '\u099E', // ঞ
            '\u099F', // ট
            '\u09A0', // ঠ
            '\u09A1', // ড
            '\u09A2', // ঢ
            '\u09A3', // ণ
            '\u09A4', // ত
            '\u09A5', // থ
            '\u09A6', // দ
            '\u09A7', // ধ
            '\u09A8', // ন
            '\u09AA', // প
            '\u09AB', // ফ
            '\u09AC', // ব
            '\u09AD', // ভ
            '\u09AE', // ম
            '\u09AF', // য
            '\u09B0', // র
            '\u09B2', // ল
            '\u09B6', // শ
            '\u09B7', // ষ
            '\u09B8', // স
            '\u09B9', // হ
            '\u09DC', // ড়
            '\u09DD'  // ঢ়
        };
            char firstAlphabet = BanglaName.Replace(" ", "").First();
            int index = banglaAlphabetUnicodeChars.FindIndex(e => e == firstAlphabet);
            return index;
        }
   

      
        public async Task<int> FloraCount()
        {
            return await _context.Floras.CountAsync();
        }
        public async Task<List<Flora?>> GetFloraList(int pageNumber, int pageSize)
        {
            List<Flora?> _floras = await _context.Floras
                  .Where(f => f.IsApprove)
                  .Include(f => f.Photos.Where(p => p.IsCoverPhoto))
                  .Include(f => f.ScientificName)
                  .OrderBy(e => e.AlphabetIndex)
                  .Skip(pageSize * pageNumber)
                  .Take(pageSize)
                  .ToListAsync<Flora?>();
            return _floras;
        }

        public async Task<bool> UpadateFlora(Flora updatedFlora)
        {
            updatedFlora.IsApprove = false;
            _context.Entry(updatedFlora).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            await _userService.deductContributionPoint(updatedFlora.Contributer);
            return true;
        }
        public async Task<List<Flora?>> GetFloraListByGenus(int pageNumber, int pageSize)
        {
            List<Flora?> _floras = await _context.Floras
                  .Include(f => f.Photos.Where(p => p.IsCoverPhoto))
                  .Include(f => f.ScientificName)
                  .OrderBy(e => e.GenusIndex)
                  .Skip(pageSize * pageNumber)
                  .Take(pageSize)
                  .ToListAsync<Flora?>();
            return _floras;
        }
        public async Task<List<Flora>> GetDisapprovePost()
        {
            List<Flora> floras = await _context.Floras.Where(f => !f.IsApprove).ToListAsync();
            return floras;
        }
        public async Task<Flora> AddFlora(Flora flora)
        {
          flora.AlphabetIndex = _GetBanglaAlphabetIndex(flora.BanglaName);
          _context.Floras.Add(flora);
          await _context.SaveChangesAsync();
          return flora;
        }

       public async Task<Flora?> GetFloraByName(string name)
        {
            Flora _flora = await _context.Floras
                .Include(f => f.ScientificName)
                .Include(f => f.Hierarchy)
                .Include(f => f.Photos)
                .FirstAsync(f => f.BanglaName == name || f.OthersName == name);
          return _flora;
        }

        public async Task<bool> deleteFlora(Guid id)
        {
            Flora? flora = await GetFloraById(id);
            if (flora == null) return false;
            _context.Floras.Remove(flora);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Flora?> GetFloraById(Guid id)
        {
            Flora flora = await _context.Floras
                .Include(f => f.Hierarchy)
                .Include(f => f.ScientificName)
                .Include(f => f.Photos)
                .FirstAsync(f => f.Id == id);
            return flora;
        }
        public async Task<List<Flora>> GetFloraByUser(string id)
        {
            List<Flora> floras = await _context.Floras
                .Include(f => f.Photos.Where(p => p.IsCoverPhoto))
                .Include(f => f.ScientificName)
                .Where(f => f.Contributer == id && f.IsApprove == true).ToListAsync();
            return floras;
        }

        public async Task<List<Flora>> GetFloraByUserAuth(string id)
        {
            List<Flora> floras = await _context.Floras
                 .Include(f => f.Photos.Where(p => p.IsCoverPhoto))
                 .Include(f => f.ScientificName)
                 .Where(f => f.Contributer == id ).ToListAsync();
            return floras;
        }

        public async Task<bool> IsExist(string name)
        {
            bool isExist = await _context.Floras.AnyAsync(f => f.ScientificName.SpecificEpithet == name);
            return isExist;
        }   

        public async Task<bool> approveFlora(Guid id)
        {
            Flora? flora = await GetFloraById(id);

            if (flora == null) return false;
            flora.IsApprove = true;
            _context.Entry(flora).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            await _userService.addContributionPoint(flora.Contributer);
            return true;
        }

        public async Task<List<Flora>> SearchByName(string SearchQuery)
        {
        var data = await _context.Floras.AsAsyncEnumerable().Where(f => BiGram.similarity(f.OthersName, SearchQuery) >= 0.0 || BiGram.similarity(f.BanglaName, SearchQuery) >= 0.0 || BiGram.similarity(f.ScientificName.Genus, SearchQuery) >= 0.0).ToListAsync();
        return data;
        } 
    }
}
