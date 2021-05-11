using SportsHubBL.Interfaces;
using SportsHubBL.Models;
using SportsHubDAL.Entities;
using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Services
{
    public class MainArticleService : IMainArticleService
    {
        private readonly INoIdRepository<MainArticle> _mainArticleRepository;
        private readonly IArticleModelService _articleModelService;
        private readonly IArticleService _articleService;

        public MainArticleService(INoIdRepository<MainArticle> mainArticleRepository, IArticleModelService articleModelService, IArticleService articleService)
        {
            _mainArticleRepository = mainArticleRepository;
            _articleModelService = articleModelService;
            _articleService = articleService;
        }

        public MainArticle AddMainArticleFromModel(MainArticleModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var mainArticle = GetMainArticleFromModel(model);

            if (mainArticle.Show && !CheckMainArticleState())
            {
                throw new Exception($"can not add main article {mainArticle.ArticleId} - reached maximum count. Remove or hide any existing main articles");
            }

            _mainArticleRepository.Insert(mainArticle);

            return mainArticle;
        }

        public void DeleteMainArticle(int mainArticleId)
        {
            var mainArticle = _mainArticleRepository.Set().FirstOrDefault(ma => ma.ArticleId == mainArticleId);

            if (mainArticle == null)
            {
                throw new Exception($"Main article {mainArticleId} not found");
            }

            _mainArticleRepository.Delete(mainArticle);
        }

        private MainArticle GetMainArticleFromModel(MainArticleModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var article = _articleService.GetArticleById(model.ArticleId);

            if (article == null)
            {
                throw new Exception($"article {model.ArticleId} not found");
            }

            return new MainArticle
            {
                ArticleId = article.Id,
                Article = article,
                Show = model.Show,
            };
        }

        public MainArticleModel GetMainArticleModel(MainArticle mainArticle)
        {
            if (mainArticle == null)
            {
                throw new ArgumentNullException(nameof(mainArticle));
            }

            return new MainArticleModel
            {
                ArticleId = mainArticle.ArticleId,
                Show = mainArticle.Show
            };
        }


        public MainArticle GetMainArticleById(int id)
        {
            return _mainArticleRepository.Set().FirstOrDefault(ma => ma.ArticleId == id);
        }

        public IEnumerable<MainArticleModel> GetMainPageArticles(bool showHidden = true)
        {
            return _mainArticleRepository.Set().Where(ma => showHidden || ma.Show == true).Select(ma => _articleModelService.GenerateMainArticleModel(ma));
        }

        public IEnumerable<MainArticle> GetMainArticles()
        {
            return _mainArticleRepository.Set().ToList();
        }

        public MainArticle UpdateMainArticleFromModel(int mainArticleId, MainArticleModel model)
        {
            var mainArticle = _mainArticleRepository.Set().FirstOrDefault(ma => ma.ArticleId == mainArticleId);

            if (mainArticle == null)
            {
                throw new Exception($"main article {mainArticleId} not found");
            }

            var newMainArticle = GetMainArticleFromModel(model);

            if (!mainArticle.Show && newMainArticle.Show && !CheckMainArticleState())
            {
                throw new Exception($"can not update status for main article {mainArticle.ArticleId} - reached maximum count. Remove or hide any existing main articles");
            }

            mainArticle.Article = newMainArticle.Article;
            mainArticle.Show = newMainArticle.Show;

            _mainArticleRepository.Update(mainArticle);

            return mainArticle;
        }

        private bool CheckMainArticleState()
        {
            if (_mainArticleRepository.Set().Count(ma => ma.Show) >= 5)
            {
                return false;
            }

            return true;
        }
    }
}
