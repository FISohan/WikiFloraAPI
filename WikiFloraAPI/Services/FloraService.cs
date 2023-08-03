using Microsoft.EntityFrameworkCore;
using WikiFloraAPI.Data;
using WikiFloraAPI.Models;

namespace WikiFloraAPI.Services
{



    public class FloraService : IFloraService
    {
        private readonly DataContext _context;


        private int _GetAlphabetIndex(string BanglaName)
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

        public FloraService(DataContext context)
        {
            _context = context;
        }
        public async Task<int> FloraCount()
        {
            return await _context.Floras.CountAsync();
        }
        public async Task<List<Flora?>> GetFloraList(int pageNumber, int pageSize)
        {
            List<Flora?> _floras = await _context.Floras
                  .Include(f => f.Photos.Where(p => p.IsCoverPhoto))
                  .OrderBy(e => e.AlphabetIndex)
                  .Skip(pageSize * pageNumber)
                  .Take(pageSize)
                  .ToListAsync<Flora?>();
            
            return _floras;
        }

      public async Task<Flora> AddFlora(Flora flora)
        {
          flora.AlphabetIndex = _GetAlphabetIndex(flora.BanglaName);
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
