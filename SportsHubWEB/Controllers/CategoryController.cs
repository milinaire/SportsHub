using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using IdentityServer4.Extensions;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace SportsHubWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
            
        [HttpGet]
        public IActionResult GetCategories(
            [FromQuery] int languageId)
        {
            try
            {
                var result = _categoryService.GetCategories(languageId);
                if(result.IsNullOrEmpty())
                    return NotFound("Categories are not found");
                return Ok(result);
            }
            catch (ArgumentException)
            {
                return BadRequest("Categories are not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
            
    }
}