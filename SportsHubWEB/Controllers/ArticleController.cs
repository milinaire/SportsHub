using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
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
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly ISportArticleService _sportArticleService;
        private readonly IArticleModelService _articleModelService;

        public ArticleController(
            IArticleService articleService,
            ISportArticleService sportArticleService,
            IArticleModelService articleModelService)
        {
            _articleService = articleService;
            _sportArticleService = sportArticleService;
            _articleModelService = articleModelService;
        }

        [HttpGet]
        public IEnumerable<ArticleModel> GetMainArticles([FromQuery] bool showHidden = false)
        {
            // TODO: cange this call to use language
            int? languageId = 1;

            var mainArticles = _articleService.GetMainPageArticles();

            var articleModels = mainArticles.Where(mam => mam.Show).Select(mam =>
            {
                var sportArticle = _sportArticleService.GetConnectedSportArticle(mam.ArticleId);
                if (sportArticle == null)
                {
                    return _articleModelService.GenerateArticleModel(_articleService.GetArticleById(mam.ArticleId), languageId ?? 1);
                }
                else
                {
                    return _sportArticleService.GenerateSportArticleModel(sportArticle, languageId ?? 1);
                }
            }
            );

            return articleModels;
        }

        [HttpPost]
        public ActionResult AddArticle([FromBody] ArticleModel model)
        {
            if (model == null)
            {
                return BadRequest("model was null");
            }

            try
            {
                _articleService.AddArticleFromModel(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateArticle([FromRoute] int id, [FromBody] ArticleModel model)
        {
            if (model == null)
            {
                return BadRequest("model was null");
            }

            try
            {
                _articleService.UpdateArticleById(id, model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteArticle([FromRoute] int id)
        {
            try
            {
                _articleService.DeleteArticleById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpGet("{id}/localization")]
        public ActionResult<IEnumerable<ArticleLocalization>> GetAllArticleLocalizations([FromRoute]int id)
        {
            try
            {
                return _articleService.GetArticleLocalizations(id).ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/localization/{languageId}")]
        public ActionResult<ArticleLocalization> GetArticleLocalization([FromRoute] int id, [FromRoute] int languageId)
        {
            try
            {
                var articleLocalization = _articleService.GetArticleLocalization(id, languageId);

                return Content(JsonSerializer.Serialize(articleLocalization), "application/json");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}/localization/{languageId}")]
        public ActionResult UpdateArticleLocalization([FromRoute] int id, [FromRoute] int languageId, [FromBody] ArticleModel model)
        {
            if (model.LanguageId != languageId || model.ArticleId != id)
            {
                return BadRequest("id\'s in the model and in the route have to be identical");
            }

            try
            {
                _articleService.UpdateArticleLocalizationFromModel(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}/localization/{languageId}")]
        public ActionResult DeleteArticleLocalization([FromRoute] int id, [FromRoute] int languageId)
        {
            try
            {
                _articleService.DeleteArticleLocalizationById(id, languageId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}
