using WikiFloraAPI.Models;

namespace WikiFloraAPI.Services
{
    public interface IFloraService
    {
       public Task<List<Flora?>> GetFloraList();
       public Task<Flora> GetSingleFlora();
       public Task<Flora> AddFlora(Flora flora);
    }
}
