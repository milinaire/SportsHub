﻿using SportsHubBL.Models;
using SportsHubDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Interfaces
{
    public interface IArticleService
    {
        public IEnumerable<Article> GetMainPageArticles(int count);

        public IEnumerable<Article> GetArticlesByCategory(int categoryId, int count);

        public ArticleLocalization GetArticleLocalization(int articleId, int languageId);

        public Content GetArticleContent(Article article);

        public Article GetArticleById(int id);

        public void AddArticleFromModel(ArticleModel model);

        public void AddNewArticleLocalizationFromModel(ArticleModel model);

        public ArticleModel GetArticleModel(Article article, Language language);

        public ArticleModel GenerateArticleModel(Article article, int languageId);

        public void DeleteArticleById(int id);

        public void DeleteArticleLocalizationById(int articleId, int languageId);

        public void UpdateArticleById(int id, ArticleModel model);

        public void UpdateArticleLocalizationFromModel(ArticleModel model);

        public IEnumerable<Article> GetMostCommentedArticles(TimeSpan timeSpan);

        public IEnumerable<Article> GetMostViewedArticles(TimeSpan timeSpan);
    }
}
