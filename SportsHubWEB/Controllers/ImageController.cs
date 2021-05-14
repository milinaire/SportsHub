using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using System;
using System.IO;
using System.Linq;
using IdentityServer4.Extensions;
using SportsHubDAL.Entities;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace SportsHubWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpPost]
        public async Task<IActionResult> UploadSingleFile([FromForm(Name = "file")] IFormFile file)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _imageService.AddImage(file);
                var imageName = file.FileName;
                var res = _imageService.AddImageToDb(imageName);
                return Content(JsonSerializer.Serialize(res), "application/json");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}