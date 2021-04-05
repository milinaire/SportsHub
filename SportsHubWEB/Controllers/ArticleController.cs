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
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [HttpGet]
        public IEnumerable<ArticleModel> GetArticlesByCategory([FromQuery]int categoryId, [FromQuery]int count = 10)
        {
            // TODO: cange this call to use language
            return articleService.GetArticlesByCategory(categoryId, count).Select(a => articleService.GenerateArticleModel(a, 1));
        }

    }
}
