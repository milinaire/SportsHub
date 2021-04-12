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

        public SportArticleController(
            ISportArticleService sportArticleService
            )
        {
            _sportArticleService = sportArticleService;
        }

        [HttpGet]
        public IEnumerable<SportArticleModel> GetSportsArticles([FromQuery] int? categoryId, [FromQuery] int? conferenceId, [FromQuery] int? teamId, [FromQuery] int? locationId, int count = 10)
        {
            // TODO: cange this call to use language
            int? languageId = 1;

            return _sportArticleService.GetSportArticles(categoryId, conferenceId, teamId, locationId, count)
                .Select(sa => _sportArticleService.GenerateSportArticleModel(sa, languageId ?? 1));
        }

    }
}
