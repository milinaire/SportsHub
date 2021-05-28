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
    [ApiController]
    [Route("article/main")]
    public class MainArticleController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        private readonly IArticleService _articleService;
        private readonly ISportArticleService _sportArticleService;
        private readonly IArticleModelService _articleModelService;
        private readonly IMainArticleService _mainArticleService;

        public MainArticleController(ILanguageService languageService, IArticleService articleService, ISportArticleService sportArticleService, IArticleModelService articleModelService, IMainArticleService mainArticleService)
        {
            _languageService = languageService;
            _articleService = articleService;
            _sportArticleService = sportArticleService;
            _articleModelService = articleModelService;
            _mainArticleService = mainArticleService;
        }

        [HttpGet("display")]
        public ActionResult<IEnumerable<ArticleModel>> GetMainArticles([FromQuery] bool showHidden = false, [FromQuery] int? languageId = null)
        {
            if (languageId == null)
            {
                languageId = _languageService.DefaultSiteLanguageId;
            }
            try
            {
                var mainArticles = _mainArticleService.GetMainPageArticles(showHidden);

                var articleModels = mainArticles.Where(mam => mam.Show).Select(mam =>
                {
                    var sportArticle = _sportArticleService.GetConnectedSportArticle(mam.ArticleId);
                    if (sportArticle == null)
                    {
                        return _articleModelService.GetLocalizedArticleModel(_articleService.GetArticleById(mam.ArticleId), (int)languageId);
                    }
                    else
                    {
                        return _sportArticleService.GenerateSportArticleModel(sportArticle, (int)languageId);
                    }
                }
                );

                return Ok(articleModels);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            
        }

        [HttpGet]
        public ActionResult<IEnumerable<MainArticleModel>> GetMainArticles()
        {
            try
            {
                return Ok(_mainArticleService.GetMainArticles().Select(ma => _mainArticleService.GetMainArticleModel(ma)));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MainArticleModel> GetMainArticleById([FromRoute] int id)
        {
            try
            {
                var mainArticle = _mainArticleService.GetMainArticleById(id);

                return _mainArticleService.GetMainArticleModel(mainArticle);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<MainArticleModel> AddMainArticle([FromBody] MainArticleModel model)
        {
            try
            {
                var newMainArticle = _mainArticleService.AddMainArticleFromModel(model);

                return _mainArticleService.GetMainArticleModel(newMainArticle);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<MainArticleModel> UpdateMainArticle([FromRoute] int id, [FromBody] MainArticleModel model)
        {
            try
            {
                if (model.ArticleId == 0 || model.ArticleId != id)
                {
                    model.ArticleId = id;
                }

                var updatedMainArticle = _mainArticleService.UpdateMainArticleFromModel(id, model);

                return _mainArticleService.GetMainArticleModel(updatedMainArticle);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMainArticle([FromRoute] int id)
        {
            try
            {
                _mainArticleService.DeleteMainArticle(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
