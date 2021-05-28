using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SportsHubWEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public IEnumerable<Language> GetLanguages()
        {
            return _languageService.GetAllLanguages();
        }

        [HttpGet("{id}")]
        public ActionResult<Language> GetLanguageById([FromRoute]int id)
        {
            try
            {
                var language = _languageService.GetLanguage(id);

                if (language == null)
                {
                    return NotFound();
                }

                return Content(JsonSerializer.Serialize(language), "application/json");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);   
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateLanguage([FromRoute]int id,[FromBody] Language language)
        {
            if (language == null)
            {
                return BadRequest("language was null");
            }

            try
            {
                _languageService.UpdateLanguage(id, language);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public ActionResult AddLanguage([FromBody] Language language)
        {
            if (language == null)
            {
                return BadRequest("language was null");
            }

            try
            {
                _languageService.AddLanguage(language);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLanguage([FromRoute]int id)
        {
            try
            {
                _languageService.DeleteLanguage(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpGet("default/{userId}")]
        public async Task<ActionResult<int>> GetDefaultLanguageIdForUserAsync([FromRoute] string userId)
        {
            try
            {
                return await _languageService.GetUserPreferredLanguageAsync(userId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("default/{userId}/{languageId}")]
        public async Task<ActionResult> SetDefaultLanguageForUserAsync([FromRoute] string userId, [FromRoute] int languageId)
        {
            try
            {
                await _languageService.SetUserPreferredLanguageAsync(userId, languageId);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
