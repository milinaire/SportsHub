using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsHubWEB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SportArticleController : ControllerBase
    {
        private readonly ISportArticleService _sportArticleService;
        private readonly ILanguageService _languageService;

        public SportArticleController(
            ISportArticleService sportArticleService,
            ILanguageService languageService)
        {
            _sportArticleService = sportArticleService;
            _languageService = languageService;
        }

        [HttpGet]
        public IEnumerable<SportArticleModel> GetSportsArticles([FromQuery] int? categoryId, [FromQuery] int? conferenceId, [FromQuery] int? teamId, [FromQuery] int? locationId, [FromQuery] int? languageId = null, int count = 10)
        {
            if (languageId == null)
            {
                languageId = _languageService.DefaultSiteLanguageId;
            }

            return _sportArticleService.GetSportArticles(categoryId, conferenceId, teamId, locationId, count)
                .Select(sa => _sportArticleService.GenerateSportArticleModel(sa, (int)languageId));
        }

        [HttpGet("{id}")]
        public ActionResult<SportArticleModel> GetSportArticleById([FromRoute] int id, [FromQuery] int? languageId)
        {
            var sportArticle = _sportArticleService.GetConnectedSportArticle(id);

            if (sportArticle == null)
            {
                return NotFound(id);
            }

            if (languageId == null)
            {
                languageId = _languageService.DefaultSiteLanguageId;
            }

            return _sportArticleService.GenerateSportArticleModel(sportArticle, (int)languageId);
        }

        [HttpPost]
        public ActionResult AddSportArticle([FromBody] SportArticleModel sportArticleModel)
        {
            if (sportArticleModel == null)
            {
                return BadRequest("model was null");
            }

            try
            {
                _sportArticleService.AddSportArticleFromModel(sportArticleModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSportArticle([FromRoute] int id, [FromBody] SportArticleModel sportArticleModel)
        {
            if (sportArticleModel == null)
            {
                return BadRequest("model was null");
            }

            try
            {
                _sportArticleService.UpdateSportArticleFromModel(id, sportArticleModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSportArtcile([FromRoute] int id)
        {
            try
            {
                _sportArticleService.DeleteSportArticle(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }
    }
}
