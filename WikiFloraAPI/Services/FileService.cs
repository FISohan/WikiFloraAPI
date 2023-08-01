using System.Diagnostics;
using WikiFloraAPI.Models;
using WikiFloraAPI.Models.Dtos;

namespace WikiFloraAPI.Services
{
    public class FileService : IFileService
    {
        public Task<string?> get(string path)
        {
            throw new NotImplementedException();
        }

        public Task<string> remove(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> upload(IFormFile file)
        {
            string fileName = file.FileName;
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;

            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "FloraPhotos", uniqueFileName);
            Console.WriteLine(imagePath);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
                return imagePath;
        }

    }
}
