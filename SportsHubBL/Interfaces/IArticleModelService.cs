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
        public ArticleModel GetArticleModel(Article article, Language language);
        public ArticleModel GenerateArticleModel(Article article, int languageId);
    }
}
