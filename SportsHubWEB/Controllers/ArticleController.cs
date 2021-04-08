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
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly ISportArticleService _sportArticleService;
        private readonly IArticleModelService _articleModelService;

        public ArticleController(
            IArticleService articleService,
            IArticleModelService articleModelService,
            ISportArticleService sportArticleService)
        {
            _articleService = articleService;
            _sportArticleService = sportArticleService;
            _articleModelService = articleModelService;
        }

        [HttpGet]
        public IEnumerable<SportArticleModel> GetSportsArticles([FromQuery]int? categoryId, [FromQuery]int? conferenceId, [FromQuery]int? teamId, [FromQuery]int? locationId, int count = 10)
        {
            // TODO: cange this call to use language
            return _sportArticleService.GetSportArticles(categoryId, conferenceId, teamId, locationId, count)
                .Select(sa => _sportArticleService.GenerateSportArticleModel(sa, 1));
        }

    }
}
