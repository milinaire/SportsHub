using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using SportsHubDAL.Entities;
using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportsHubBL.Services
{
    public class SportArticleService: ISportArticleService
    {
        private readonly IArticleModelService _articleModelService;
        private readonly IArticleService _articleService;
        private readonly IRepository<Team> _teamRepository;
        private readonly INoIdRepository<SportArticle> _sportArticleRepository;

        public SportArticleService(
            IArticleModelService articleModelService,
            INoIdRepository<SportArticle> sportArticleRepository,
            IRepository<Team> teamRepository, IArticleService articleService)
        {
            _articleModelService = articleModelService;
            _sportArticleRepository = sportArticleRepository;
            _teamRepository = teamRepository;
            _articleService = articleService;
        }

        public SportArticle GetConnectedSportArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            return _sportArticleRepository.Set().Include(sa => sa.Article).FirstOrDefault(sa => sa.Article == article);
        }

        public SportArticle GetModel(SportArticle article)
        {
            return new()
            {
                ArticleId = article.ArticleId,
                TeamId = article.TeamId,
            };
        }

        public SportArticle GetConnectedSportArticle(int articleId)
        {
            return _sportArticleRepository.Set().FirstOrDefault(sa => sa.ArticleId == articleId);
        }

        public SportArticle AddSportArticleFromModel(SportArticleModel model)
        {
            var sportArticle = GetSportArticleFromModel(model);

            _sportArticleRepository.Insert(sportArticle);

            return sportArticle;
        }

        public SportArticle UpdateSportArticleFromModel(int sportArticleId, SportArticleModel model)
        {
            var sportArticle = _sportArticleRepository.Set()
                .FirstOrDefault(sa => sa.ArticleId == sportArticleId);

            if (sportArticle == null)
            {
                throw new Exception($"SportArticle {sportArticleId} not found");
            }

            var newSportArticle = GetSportArticleFromModel(model);

            sportArticle.ArticleId = newSportArticle.ArticleId;
            sportArticle.TeamId = newSportArticle.TeamId;

            _sportArticleRepository.Update(sportArticle);

            return sportArticle;
        }

        public void DeleteSportArticle(int sportArticleId)
        {
            var sportArticle = _sportArticleRepository.Set()
                .FirstOrDefault(sa => sa.ArticleId == sportArticleId);

            if (sportArticle == null)
            {
                throw new Exception($"SportArticle {sportArticleId} not found");
            }

            _sportArticleRepository.Delete(sportArticle);
        }

        public IEnumerable<SportArticle> GetSportArticles(int? categoryId, int? conferenceId, int? teamId, int? locationId, int count = 10)
        {
            if (count <= 0)
            {
                throw new ArgumentException($"{nameof(count)} must be greater than 0", nameof(count));
            }

            var query = from a in _sportArticleRepository.Set()
                        .Include(sa => sa.Article).ThenInclude(saa => saa.Category)
                        .Include(sa => sa.Team).ThenInclude(t => t.Conference)
                        .Include(sa => sa.Team).ThenInclude(sa => sa.Location)
                        where categoryId == null || a.Article.Category != null && a.Article.Category.Id == categoryId
                        where conferenceId == null || a.Team.Conference.Id == conferenceId
                        where teamId == null || a.TeamId == teamId
                        where locationId == null || a.Team.Location.Id == locationId
                        select a;

            return query.Take(count).ToList();
        }

        private SportArticleModel LocalizeSportArticleModel(SportArticleModel model, SportArticle sportArticle, int languageId)
        {
            if (sportArticle?.Article == null
                || sportArticle?.Team == null)
            {
                sportArticle = _sportArticleRepository.Set()
                    .Include(sa => sa.Article)
                    .Include(sa => sa.Team).ThenInclude(t => t.TeamLocalizations)
                    .Include(sa => sa.Team).ThenInclude(t => t.Conference).ThenInclude(c => c.ConferenceLocalizations)
                    .Include(sa => sa.Team).ThenInclude(t => t.Location)
                    .FirstOrDefault(sa => sa == sportArticle);
            }

            model.LocationId = sportArticle.Team.Location.Id;
            model.LocationUri = sportArticle.Team.Location.Uri;
            //TODO: English language default id in call
            model.TeamId = sportArticle.Team.Id;
            model.TeamName = sportArticle.Team.TeamLocalizations
                .FirstOrDefault(tl => tl.LanguageId == languageId)?.Name ??
                sportArticle.Team.TeamLocalizations.FirstOrDefault(tl => tl.LanguageId == 1/*english*/)?.Name;
            //TODO: English language default id in call
            model.ConferenceId = sportArticle.Team.Conference.Id;
            model.ConferenceName = sportArticle.Team.Conference.ConferenceLocalizations
                .FirstOrDefault(cl => cl.LanguageId == languageId)?.Name ??
                sportArticle.Team.Conference.ConferenceLocalizations.FirstOrDefault(cl => cl.LanguageId == 1/*english*/)?.Name;

            return model;
        }

        public SportArticleModel GenerateSportArticleModel(SportArticle sportArticle, int languageId)
        {
            if (sportArticle?.Article == null
                || sportArticle?.Team == null)
            {
                sportArticle = _sportArticleRepository.Set()
                    .Include(sa => sa.Article)
                    .Include(sa => sa.Team).ThenInclude(t => t.TeamLocalizations)
                    .Include(sa=> sa.Team).ThenInclude(t => t.Conference).ThenInclude(c => c.ConferenceLocalizations)
                    .Include(sa => sa.Team).ThenInclude(t => t.Location)
                    .FirstOrDefault(sa => sa == sportArticle);
            }

            if (sportArticle == null)
            {
                throw new ArgumentNullException(nameof(sportArticle));
            }

            var articleModel = _articleModelService.GetLocalizedArticleModel(sportArticle.Article, languageId);

            var sportArticleModel = LocalizeSportArticleModel(new SportArticleModel(articleModel), sportArticle, languageId);

            return sportArticleModel;
        }

        private SportArticle GetSportArticleFromModel(SportArticleModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var article = _articleService.GetArticleById(model.ArticleId)?? _articleModelService.GetArticleFromModel(model);

            var team = _teamRepository.Set()
                .FirstOrDefault(t => t.Id == model.TeamId) ??
                throw new Exception($"team {model.TeamId} doesn\'t exist");

            return new SportArticle
            {
                ArticleId = model.ArticleId,
                Article = article,
                Team = team,
            };
        }
    }
}
