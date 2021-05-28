using SportsHubBL.Models;
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
        public ArticleLocalization GetArticleLocalization(int articleId, int languageId);

        public IEnumerable<ArticleLocalization> GetArticleLocalizations(int articleId);

        public Article GetArticleById(int id);

        public IEnumerable<Article> GetAllArticles();

        public Article AddArticleFromModel(ArticleModel model);

        public ArticleLocalization AddNewArticleLocalizationFromModel(ArticleModel model);

        public void DeleteArticleById(int id);

        public void DeleteArticleLocalizationById(int articleId, int languageId);

        public Article UpdateArticleById(int id, ArticleModel model);

        public ArticleLocalization UpdateArticleLocalizationFromModel(ArticleModel model);

        public IEnumerable<Article> GetMostCommentedArticles(TimeSpan timeSpan);

        public IEnumerable<Article> GetMostViewedArticles(TimeSpan timeSpan);
    }
}
