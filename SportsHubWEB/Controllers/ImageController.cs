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
        [HttpGet("{id:int}")]
        public IActionResult GetImageById(int id)
        {
            try
            {
                var result = _imageService.GetImageById(id);
                if(result == null)
                    return NotFound("Image is not found");
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> UploadAnImage([FromForm(Name = "file")] IFormFile file)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var imageName = (DateTime.Now + file.FileName).Replace(' ','-');
                await _imageService.AddImage(file, imageName);
                var res = _imageService.AddImageToDb(imageName);
                return Content(JsonSerializer.Serialize(res), "application/json");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateImageById([FromForm(Name = "file")] IFormFile file, int id)
        {
            try
            {
                if (file == null)
                {
                    throw new Exception("File was null");
                }
                var imageName = (DateTime.Now + file.FileName).Replace(' ','-');
                await _imageService.AddImage(file,imageName);
                var res = _imageService.UpdateImageById(id, file.FileName);
                return Content(JsonSerializer.Serialize(res), "application/json");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteTeamById([FromRoute]int id)
        {
            try
            {
                _imageService.DeleteImageById(id);
                return Ok($"Image {id} successfully deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}