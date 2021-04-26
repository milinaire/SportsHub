using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using SportsHubDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<ArticleModel> GetMainArticles()
        {
            // TODO: cange this call to use language
            int? languageId = 1;

            var mainArticles = _articleService.GetMainPageArticles();

            var articleModels = mainArticles.Where(mam => mam.Show).Select(mam =>
            {
                var sportArticle = _sportArticleService.GetConnectedSportArticle(mam.ArticleId);
                if (sportArticle == null)
                {
                    return _articleModelService.GenerateArticleModel(_articleService.GetArticleById(mam.ArticleId), languageId?? 1);
                }
                else
                {
                    return _sportArticleService.GenerateSportArticleModel(sportArticle, languageId?? 1);
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


    }
}
