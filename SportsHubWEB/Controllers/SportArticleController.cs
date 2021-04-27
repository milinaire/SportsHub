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
        private readonly IArticleService _articleService;

        public SportArticleController(
            ISportArticleService sportArticleService,
            IArticleService articleService)
        {
            _sportArticleService = sportArticleService;
            _articleService = articleService;
        }

        [HttpGet]
        public IEnumerable<SportArticleModel> GetSportsArticles([FromQuery] int? categoryId, [FromQuery] int? conferenceId, [FromQuery] int? teamId, [FromQuery] int? locationId, int count = 10)
        {
            // TODO: cange this call to use language
            int? languageId = 1;

            return _sportArticleService.GetSportArticles(categoryId, conferenceId, teamId, locationId, count)
                .Select(sa => _sportArticleService.GenerateSportArticleModel(sa, languageId ?? 1));
        }

        [HttpGet("{id}")]
        public ActionResult<SportArticleModel> GetSportArticleById([FromRoute] int id)
        {
            var sportArticle = _sportArticleService.GetConnectedSportArticle(id);

            if (sportArticle == null)
            {
                return NotFound(id);
            }
            // TODO: cange this call to use language
            int? languageId = 1;

            return _sportArticleService.GenerateSportArticleModel(sportArticle, languageId ?? 1);
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
                _articleService.AddNewArticleLocalizationFromModel(sportArticleModel);
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
                _articleService.UpdateArticleLocalizationFromModel(sportArticleModel);
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
