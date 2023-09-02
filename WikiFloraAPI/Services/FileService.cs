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

        public string remove(string fileName)
        {
            
            string directory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(directory,"FloraPhotos", fileName);
            try { File.Delete(filePath); } catch(Exception ex) { return ex.Message; }
            return fileName;
        }

        public async Task<string?> upload(IFormFile file)
        {
            string fileName = file.FileName;
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;

            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "FloraPhotos", uniqueFileName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
             return uniqueFileName;
        }

    }
}
