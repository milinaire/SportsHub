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
        private readonly IRepository<Team> _teamRepository;
        private readonly INoIdRepository<SportArticle> _sportArticleRepository;

        public SportArticleService(
            IArticleModelService articleModelService,
            INoIdRepository<SportArticle> sportArticleRepository,
            IRepository<Team> teamRepository)
        {
            _articleModelService = articleModelService;
            _sportArticleRepository = sportArticleRepository;
            _teamRepository = teamRepository;
        }

        public SportArticle GetConnectedSportArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            return _sportArticleRepository.Set().Include(sa => sa.Article).FirstOrDefault(sa => sa.Article == article);
        }

        public SportArticle GetConnectedSportArticle(int articleId)
        {
            return _sportArticleRepository.Set().FirstOrDefault(sa => sa.ArticleId == articleId);
        }

        public void AddSportArticleFromModel(SportArticleModel model)
        {
            var sportArticle = GetSportArticleFromModel(model);

            _sportArticleRepository.Insert(sportArticle);
        }

        public void UpdateSportArticleFromModel(int sportArticleId, SportArticleModel model)
        {
            var sportArticle = _sportArticleRepository.Set()
                .FirstOrDefault(sa => sa.ArticleId == model.ArticleId);

            if (sportArticle == null)
            {
                throw new ArgumentException($"SportArticle {sportArticleId} not found", nameof(sportArticleId));
            }

            var newSportArticle = GetSportArticleFromModel(model);

            sportArticle.ArticleId = newSportArticle.ArticleId;
            sportArticle.TeamId = newSportArticle.TeamId;

            _sportArticleRepository.Update(sportArticle);
        }

        public void DeleteSportArticle(int sportArticleId)
        {
            var sportArticle = _sportArticleRepository.Set()
                .FirstOrDefault(sa => sa.ArticleId == sportArticleId);

            if (sportArticle == null)
            {
                throw new ArgumentException($"SportArticle {sportArticleId} not found", nameof(sportArticleId));
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

            var articleModel = _articleModelService.GenerateArticleModel(sportArticle.Article, languageId);

            var sportArticleModel = LocalizeSportArticleModel((SportArticleModel)articleModel, sportArticle, languageId);

            return sportArticleModel;
        }

        private SportArticle GetSportArticleFromModel(SportArticleModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var article = _articleModelService.GetArticleFromModel(model);

            var team = _teamRepository.Set()
                .FirstOrDefault(t => t.Id == model.TeamId) ??
                throw new ArgumentException($"team {model.TeamId} doesn\'t exist", nameof(model));

            return new SportArticle
            {
                Article = article,
                Team = team
            };
        }
    }
}
