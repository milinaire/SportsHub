﻿using SportsHubBL.Models;
using SportsHubDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Interfaces
{
    public interface ISportArticleService
    {
        public IEnumerable<SportArticle> GetSportArticles(int? categoryId, int? conferenceId, int? teamId, int? locationId, int count);

        public SportArticleModel GenerateSportArticleModel(SportArticle sportArticle, int languageId);

        public SportArticle GetConnectedSportArticle(Article article);

        public SportArticle GetConnectedSportArticle(int articleId);

        public void AddSportArticleFromModel(SportArticleModel model);

        public void UpdateSportArticleFromModel(int sportArticleId, SportArticleModel model);

        public void DeleteSportArticle(int sportArticleId);
    }
}