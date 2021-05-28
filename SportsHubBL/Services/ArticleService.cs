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

        public ArticleService(
            INoIdRepository<Article> articleRepository,
            INoIdRepository<Language> languageRepository,
            INoIdRepository<ArticleLocalization> articleLocalizationRepository,
            IArticleModelService articleModelService
            )
        {
            _articleModelService = articleModelService;
            _articleRepository = articleRepository;
            _languageRepository = languageRepository;
            _articleLocalizationRepository = articleLocalizationRepository;
        }

        public Article AddArticleFromModel(ArticleModel model)
        {
            var article = _articleModelService.GetArticleFromModel(model);

            _articleRepository.Insert(article);

            return article;
        }

        public void DeleteArticleById(int id)
        {
            var article = _articleRepository.Set().FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                throw new Exception($"Article {id} not found");
            }

            _articleRepository.Delete(article);
        }

        public Article UpdateArticleById(int id, ArticleModel model)
        {
            var originalArticle = _articleRepository.Set().FirstOrDefault(a => a.Id == id);

            if (originalArticle == null)
            {
                throw new Exception($"can\'t find article {id}");
            }

            var article = _articleModelService.GetArticleFromModel(model);


            originalArticle.Image = article.Image;
            originalArticle.Category = article.Category;
            originalArticle.Content = article.Content;

            _articleRepository.Update(originalArticle);

            return originalArticle;
        }

        public Article GetArticleById(int id)
        {
            var article = _articleRepository.Set().FirstOrDefault(a => a.Id == id);

            return article;
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
                throw new Exception("article was null");
            }

            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new Exception("language was null");
            }

            return _articleLocalizationRepository.Set().FirstOrDefault(al => al.Article == article && al.Language == language);
        }

        public ArticleLocalization AddNewArticleLocalizationFromModel(ArticleModel model)
        {
            var article = GetArticleById(model.ArticleId);

            var articleLocalization = _articleModelService.GetArticleLocalizationFromModel(article, model);

            if (_articleLocalizationRepository.Set()
                .Any(al => al.ArticleId == model.ArticleId && al.LanguageId == model.LanguageId))
            {
                throw new Exception($"localization in language {model.LanguageId} for article {model.ArticleId} already exists");
            }

            _articleLocalizationRepository.Insert(articleLocalization);

            return articleLocalization;
        }

        public ArticleLocalization UpdateArticleLocalizationFromModel(ArticleModel model)
        {
            var article = GetArticleById(model.ArticleId);

            var originalArticleLocalization = _articleLocalizationRepository.Set()
                .FirstOrDefault(al => al.ArticleId == article.Id && al.LanguageId == model.LanguageId);

            if (originalArticleLocalization == null)
            {
                throw new Exception($"no previous localization in language {model.LanguageId} of article {model.ArticleId}");
            }

            var newArticleLocalization = _articleModelService.GetArticleLocalizationFromModel(article, model);

            originalArticleLocalization.Headline = newArticleLocalization.Headline;
            originalArticleLocalization.Text = newArticleLocalization.Text;
            originalArticleLocalization.Caption = newArticleLocalization.Caption;
            originalArticleLocalization.Alt = newArticleLocalization.Alt;

            _articleLocalizationRepository.Update(originalArticleLocalization);

            return originalArticleLocalization;
        }

        public void DeleteArticleLocalizationById(int articleId, int languageId)
        {
            var articleLocalization = _articleLocalizationRepository.Set()
                .FirstOrDefault(al => al.ArticleId == articleId && al.LanguageId == languageId);

            if (articleLocalization == null)
            {
                throw new Exception($"localization for article {articleId} in language {languageId} not found");
            }

            _articleLocalizationRepository.Delete(articleLocalization);
        }

        public IEnumerable<ArticleLocalization> GetArticleLocalizations(int articleId)
        {
            return _articleLocalizationRepository.Set().Where(al => al.ArticleId == articleId);
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _articleRepository.Set().ToList();
        }
    }
}
