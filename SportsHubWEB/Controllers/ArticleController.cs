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
        private readonly ILanguageService _languageService;

        public ArticleController(
            IArticleService articleService,
            ISportArticleService sportArticleService,
            IArticleModelService articleModelService, 
            ILanguageService languageService)
        {
            _articleService = articleService;
            _sportArticleService = sportArticleService;
            _articleModelService = articleModelService;
            _languageService = languageService;
        }
        [HttpGet] 
        public ActionResult<IEnumerable<ArticleModel>> GetArticles([FromQuery] int? languageId = null)
        {
            var articles = _articleService.GetAllArticles();

            try
            {
                IEnumerable<ArticleModel> models;

                if (languageId == null)
                {
                    models = articles.Select(a => _articleModelService.GetBaseArticleModel(a));
                }
                else
                {
                    models = articles.Select(a => _articleModelService.GetLocalizedArticleModel(a, (int)languageId));
                }
                return Ok(models);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ArticleModel> GetArticleById([FromRoute] int id, [FromQuery]int? languageId = null)
        {
            try
            {
                ArticleModel model;

                if (languageId == null)
                {
                    model = _articleModelService.GetBaseArticleModel(_articleService.GetArticleById(id));
                }
                else
                {
                    model = _articleModelService.GetLocalizedArticleModel(id, (int)languageId);
                }
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public ActionResult<ArticleModel> AddArticle([FromBody] ArticleModel model)
        {
            if (model == null)
            {
                return BadRequest("model was null");
            }

            try
            {
                var res =  _articleService.AddArticleFromModel(model);
                return _articleModelService.GetBaseArticleModel(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ArticleModel> UpdateArticle([FromRoute] int id, [FromBody] ArticleModel model)
        {
            if (model == null)
            {
                return BadRequest("model was null");
            }

            try
            {
                var res =  _articleService.UpdateArticleById(id, model);
                return _articleModelService.GetBaseArticleModel(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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

        [HttpPost("{id}/localization")]
        public ActionResult<ArticleModel> AddArticleLocalization([FromRoute]int id, [FromBody] ArticleModel model)
        {
            if (model.ArticleId != id)
            {
                return BadRequest("id\'s in the model and in the route have to be identical");
            }

            try
            {
                var res =  _articleService.AddNewArticleLocalizationFromModel(model);
                return _articleModelService.GetLocalizedArticleModel(res.ArticleId, res.LanguageId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/localization")]
        public ActionResult<IEnumerable<ArticleLocalization>> GetAllArticleLocalizations([FromRoute] int id)
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
        public ActionResult<ArticleModel> UpdateArticleLocalization([FromRoute] int id, [FromRoute] int languageId, [FromBody] ArticleModel model)
        {
            if (model.LanguageId != languageId || model.ArticleId != id)
            {
                return BadRequest("id\'s in the model and in the route have to be identical");
            }

            try
            {
                
                var res =  _articleService.UpdateArticleLocalizationFromModel(model);
                return _articleModelService.GetLocalizedArticleModel(res.ArticleId, res.LanguageId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
