﻿using SportsHubBL.Interfaces;
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
        private readonly IArticleService _articleService;
        private readonly IArticleModelService _articleModelService;
        private readonly INoIdRepository<Location> _locationRepository;
        private readonly INoIdRepository<Team> _teamRepository;
        private readonly INoIdRepository<Conference> _conferenceRepository;
        private readonly INoIdRepository<SportArticle> _sportArticleRepository;

        public SportArticleService(
            IArticleService articleService,
            IArticleModelService articleModelService,
            INoIdRepository<SportArticle> sportArticleRepository,
            INoIdRepository<Location> locationRepository,
            INoIdRepository<Team> teamRepository,
            INoIdRepository<Conference> conferenceRepository)
        {
            _articleService = articleService;
            _articleModelService = articleModelService;
            _sportArticleRepository = sportArticleRepository;
            _locationRepository = locationRepository;
            _teamRepository = teamRepository;
            _conferenceRepository = conferenceRepository;
        }

        public SportArticle GetConnectedSportArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            return _sportArticleRepository.Set().Include(sa => sa.Article).FirstOrDefault(sa => sa.Article == article);
        }

        public void AddSportArticleFromModel(SportArticleModel model)
        {
            var sportArticle = GetSportArticleFromModel(model);

            _sportArticleRepository.Insert(sportArticle);
        }

        public IEnumerable<SportArticle> GetSportArticles(int? categoryId, int? conferenceId, int? teamId, int? locationId, int count = 10)
        {
            if (count <= 0)
            {
                throw new ArgumentException($"{nameof(count)} must be greater than 0", nameof(count));
            }

            var query = from a in _sportArticleRepository.Set()
                        .Include(sa => sa.Article).ThenInclude(saa => saa.Category)
                        where categoryId == null || a.Article.Category != null && a.Article.Category.Id == categoryId
                        where conferenceId == null || a.ConferenceId == conferenceId
                        where teamId == null || a.TeamId == teamId
                        where locationId == null || a.LocationId == locationId
                        select a;

            return query.Take(count).ToList();
        }

        private SportArticleModel LocalizeSportArticleModel(SportArticleModel model, SportArticle sportArticle, int languageId)
        {
            if (sportArticle?.Article == null
                || sportArticle?.Team == null
                || sportArticle?.Conference == null
                || sportArticle?.Location == null)
            {
                sportArticle = _sportArticleRepository.Set()
                    .Include(sa => sa.Article)
                    .Include(sa => sa.Team).ThenInclude(t => t.TeamLocalizations)
                    .Include(sa => sa.Conference).ThenInclude(c => c.ConferenceLocalizations)
                    .Include(sa => sa.Location)
                    .FirstOrDefault(sa => sa == sportArticle);
            }

            model.LocationId = sportArticle.Location.Id;
            model.LocationUri = sportArticle.Location.Uri;
            //TODO: English language default id in call
            model.TeamId = sportArticle.Team.Id;
            model.TeamName = sportArticle.Team.TeamLocalizations
                .FirstOrDefault(tl => tl.LanguageId == languageId)?.Name ??
                sportArticle.Team.TeamLocalizations.FirstOrDefault(tl => tl.LanguageId == 1/*english*/)?.Name;
            //TODO: English language default id in call
            model.ConferenceId = sportArticle.Conference.Id;
            model.ConferenceName = sportArticle.Conference.ConferenceLocalizations
                .FirstOrDefault(cl => cl.LanguageId == languageId)?.Name ??
                sportArticle.Team.Conference.ConferenceLocalizations.FirstOrDefault(cl => cl.LanguageId == 1/*english*/)?.Name;

            return model;
        }

        public SportArticleModel GenerateSportArticleModel(SportArticle sportArticle, int languageId)
        {
            if (sportArticle?.Article == null
                || sportArticle?.Team == null
                || sportArticle?.Conference == null
                || sportArticle?.Location == null)
            {
                sportArticle = _sportArticleRepository.Set()
                    .Include(sa => sa.Article)
                    .Include(sa => sa.Team).ThenInclude(t => t.TeamLocalizations)
                    .Include(sa => sa.Conference).ThenInclude(c => c.ConferenceLocalizations)
                    .Include(sa => sa.Location)
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

            var location = _locationRepository.Set()
                .FirstOrDefault(l => l.Id == model.LocationId) ??
                throw new ArgumentException($"location {model.LocationId} doesn\'t exist", nameof(model));

            var team = _teamRepository.Set()
                .FirstOrDefault(t => t.Id == model.TeamId) ??
                throw new ArgumentException($"team {model.TeamId} doesn\'t exist", nameof(model));

            var conference = _conferenceRepository.Set()
                .FirstOrDefault(c => c.Id == model.ConferenceId) ??
                throw new ArgumentException($"conference {model.ConferenceId} doesn\'t exist", nameof(model));

            return new SportArticle
            {
                Article = article,
                Location = location,
                Team = team,
                Conference = conference
            };
        }
    }
}
