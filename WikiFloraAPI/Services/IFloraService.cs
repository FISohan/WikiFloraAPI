using WikiFloraAPI.Models;

namespace WikiFloraAPI.Services
{
    public interface IFloraService
    {
       public Task<List<Flora?>> GetFloraList(int pageSize,int pageNumber);
       public Task<Flora?> GetFloraByName(string name);
       public Task<Flora> AddFlora(Flora flora);
       public Task<int> FloraCount();
       public Task<List<Flora?>> GetFloraListByGenus(int pageNumber, int pageSize);
       public Task<Flora?> GetFloraById(Guid id);
        public Task<List<Flora>> GetDisapprovePost();
        public Task<bool> approveFlora(Guid id);
    }
}   
