using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WikiFloraAPI.Models.Dtos;
using WikiFloraAPI.Services;

namespace WikiFloraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<ActionResult<PhotoUploadResponseDto>> UploadFile(IFormFile file)
        {
            string? filePath = await _fileService.upload(file);
            if (filePath == null) return BadRequest();
            string hostPath = HttpContext.Request.Host.Value;
            bool isHttps = HttpContext.Request.IsHttps;
            string photoUrl = Path.Combine(isHttps ? "https://" : "http://", hostPath,"photo",filePath);
            photoUrl = photoUrl.Replace(@"\","/");
            PhotoUploadResponseDto photoUploadResponse = new PhotoUploadResponseDto();
            photoUploadResponse.url = photoUrl;
            return Ok(photoUploadResponse);
        }
        [HttpDelete("remove")]
        public async Task<ActionResult<string>>RemoveFile(string fileName)
        {
            string s =  _fileService.remove(fileName);
            return Ok(s);
        }

    }   
}
