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
    public class ArticleService : IArticleService
    {
        private readonly INoIdRepository<Article> _articleRepository;
        private readonly INoIdRepository<Language> _languageRepository;
        private readonly INoIdRepository<ArticleLocalization> _articleLocalizationRepository;
        private readonly IArticleModelService _articleModelService;
        private readonly IRepository<MainArticle> _mainArticlesRepository;

        public ArticleService(
            INoIdRepository<Article> articleRepository,
            INoIdRepository<Language> languageRepository,
            INoIdRepository<ArticleLocalization> articleLocalizationRepository,
            IArticleModelService articleModelService,
            IRepository<MainArticle> mainArticlesRepository
            )
        {
            _articleModelService = articleModelService;
            _articleRepository = articleRepository;
            _languageRepository = languageRepository;
            _articleLocalizationRepository = articleLocalizationRepository;
            _mainArticlesRepository = mainArticlesRepository;
        }

        public void AddArticleFromModel(ArticleModel model)
        {
            var article = _articleModelService.GetArticleFromModel(model);

            _articleRepository.Insert(article);
        }

        public void DeleteArticleById(int id)
        {
            var article = _articleRepository.Set().FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                throw new ArgumentException($"Article {id} not found", nameof(id));
            }

            _articleRepository.Delete(article);
        }

        public void UpdateArticleById(int id, ArticleModel model)
        {
            var originalArticle = _articleRepository.Set().FirstOrDefault(a => a.Id == id);

            if (originalArticle == null)
            {
                throw new ArgumentException($"can\'t find article {id}", nameof(id));
            }

            var article = _articleModelService.GetArticleFromModel(model);


            originalArticle.Image = article.Image;
            originalArticle.Category = article.Category;
            originalArticle.Content = article.Content;

            _articleRepository.Update(originalArticle);
        }

        public Article GetArticleById(int id)
        {
            var article = _articleRepository.Set().FirstOrDefault(a => a.Id == id);

            return article;
        }

        public IEnumerable<MainArticleModel> GetMainPageArticles()
        {
            return _mainArticlesRepository.Set().Select(ma => _articleModelService.GenerateMainArticleModel(ma));
        }

        public IEnumerable<Article> GetMostCommentedArticles(TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetMostViewedArticles(TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        public ArticleLocalization GetArticleLocalization(int articleId, int languageId)
        {
            var article = _articleRepository.Set().FirstOrDefault(a => a.Id == articleId);

            if (article == null)
            {
                throw new ArgumentException("article was null", nameof(articleId));
            }

            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new ArgumentException("language was null", nameof(languageId));
            }

            return _articleLocalizationRepository.Set().FirstOrDefault(al => al.Article == article && al.Language == language);
        }

        public void AddNewArticleLocalizationFromModel(ArticleModel model)
        {
            var article = _articleModelService.GetArticleFromModel(model);

            var articleLocalization = _articleModelService.GetArticleLocalizationFromModel(article, model);

            if (_articleLocalizationRepository.Set()
                .Any(al => al.ArticleId == model.ArticleId && al.LanguageId == model.LanguageId))
            {
                throw new ArgumentException($"localization in language {model.LanguageId} for article {model.ArticleId} already exists", nameof(model));
            }

            _articleLocalizationRepository.Insert(articleLocalization);
        }

        public void UpdateArticleLocalizationFromModel(ArticleModel model)
        {
            var article = _articleModelService.GetArticleFromModel(model);

            var originalArticleLocalization = _articleLocalizationRepository.Set()
                .FirstOrDefault(al => al.ArticleId == article.Id && al.LanguageId == model.LanguageId);

            if (originalArticleLocalization == null)
            {
                throw new ArgumentException($"no previous localization in language {model.LanguageId} of article {model.ArticleId}", nameof(model));
            }

            var newArticleLocalization = _articleModelService.GetArticleLocalizationFromModel(article, model);

            originalArticleLocalization.Headline = newArticleLocalization.Headline;
            originalArticleLocalization.Text = newArticleLocalization.Text;
            originalArticleLocalization.Caption = newArticleLocalization.Caption;
            originalArticleLocalization.Alt = newArticleLocalization.Alt;

            _articleLocalizationRepository.Update(originalArticleLocalization);
        }

        public void DeleteArticleLocalizationById(int articleId, int languageId)
        {
            var articleLocalization = _articleLocalizationRepository.Set()
                .FirstOrDefault(al => al.ArticleId == articleId && al.LanguageId == languageId);

            if (articleLocalization == null)
            {
                throw new ArgumentException($"localization for article {articleId} in language {languageId} not found");
            }

            _articleLocalizationRepository.Delete(articleLocalization);
        }
    }
}
