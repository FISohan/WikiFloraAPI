﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<string?>> UploadFile(IFormFile file)
        {
            string? filePath = await _fileService.upload(file);
            if (filePath == null) return BadRequest();
            string hostPath = HttpContext.Request.Host.Value;
            bool isHttps = HttpContext.Request.IsHttps;
            string photoUrl = Path.Combine(isHttps ? "https://" : "http://", hostPath,"photo",filePath);
            return Ok(photoUrl);
        }
    }
}
