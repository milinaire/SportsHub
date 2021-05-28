using SportsHubBL.Models;
using SportsHubDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Interfaces
{
    public interface IMainArticleService
    {
        public IEnumerable<MainArticle> GetMainArticles();

        public IEnumerable<MainArticleModel> GetMainPageArticles(bool showHidden = true);

        public MainArticle AddMainArticleFromModel(MainArticleModel model);

        public MainArticle UpdateMainArticleFromModel(int mainArticleId, MainArticleModel model);

        public void DeleteMainArticle(int mainArticleId);

        public MainArticle GetMainArticleById(int id);

        public MainArticleModel GetMainArticleModel(MainArticle mainArticle);
    }
}
