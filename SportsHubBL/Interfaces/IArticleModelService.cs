using SportsHubBL.Models;
using SportsHubDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Interfaces
{
    public interface IArticleModelService
    {
        public Article GetArticleFromModel(ArticleModel model);
        public ArticleLocalization GetArticleLocalizationFromModel(Article article, ArticleModel model);
        public ArticleModel GetLocalizedArticleModel(Article article, Language language);
        public ArticleModel GetLocalizedArticleModel(Article article, int languageId);
        public ArticleModel GetBaseArticleModel(Article article);
        public MainArticleModel GenerateMainArticleModel(MainArticle mainArticle);
    }
}
