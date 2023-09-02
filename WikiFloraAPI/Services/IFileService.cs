using WikiFloraAPI.Models;
using WikiFloraAPI.Models.Dtos;

namespace WikiFloraAPI.Services
{
    public interface IFileService
    {
        public Task<string?> upload(IFormFile file);
        public Task<string?> get(string path);
        public string remove(string path);
    }
}
