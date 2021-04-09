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
        private readonly INoIdRepository<Article> articleRepository;
        private readonly INoIdRepository<Language> languageRepository;
        private readonly INoIdRepository<ArticleLocalization> articleLocalizationRepository;
        private readonly INoIdRepository<Content> _contentRepository;
        private readonly IArticleModelService _articleModelService;

        public ArticleService(
            INoIdRepository<Article> articleRepository,
            INoIdRepository<Language> languageRepository,
            INoIdRepository<ArticleLocalization> articleLocalizationRepository,
            IArticleModelService articleModelService,
            INoIdRepository<Content> contentRepository
            )
        {
            _articleModelService = articleModelService;
            this.articleRepository = articleRepository;
            this.languageRepository = languageRepository;
            this.articleLocalizationRepository = articleLocalizationRepository;
            _contentRepository = contentRepository;
        }

        public void AddArticleFromModel(ArticleModel model)
        {
            var article = _articleModelService.GetArticleFromModel(model);

            articleRepository.Insert(article);
        }

        public void DeleteArticleById(int id)
        {
            var article = articleRepository.Set().FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                throw new ArgumentException($"Article {id} not found", nameof(id));
            }

            articleRepository.Delete(article);
        }

        public void UpdateArticleById(int id, ArticleModel model)
        {
            var originalArticle = articleRepository.Set().FirstOrDefault(a => a.Id == id);

            if (originalArticle == null)
            {
                throw new ArgumentException($"can\'t find article {id}", nameof(id));
            }

            var article = _articleModelService.GetArticleFromModel(model);


            originalArticle.Image = article.Image;
            originalArticle.Category = article.Category;
            originalArticle.Content = article.Content;

            articleRepository.Update(originalArticle);
        }

        public Article GetArticleById(int id)
        {
            var article = articleRepository.Set().FirstOrDefault(a => a.Id == id);

            return article;
        }

        public Content GetArticleContent(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            return _contentRepository.Set().FirstOrDefault(c => c.Article == article);
        }
        public IEnumerable<Article> GetMainPageArticles(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetMostCommentedArticles(TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetMostViewedArticles(TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }


        //TODO: Move to localization service
        #region Move to localization service
        public ArticleLocalization GetArticleLocalization(int articleId, int languageId)
        {
            var article = articleRepository.Set().FirstOrDefault(a => a.Id == articleId);

            if (article == null)
            {
                throw new ArgumentException("article was null", nameof(articleId));
            }

            var language = languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new ArgumentException("language was null", nameof(languageId));
            }

            return articleLocalizationRepository.Set().FirstOrDefault(al => al.Article == article && al.Language == language);
        }

        public void AddArticleLocalizationFromModel(ArticleModel model)
        {
            var article = _articleModelService.GetArticleFromModel(model);

            var articleLocalization = _articleModelService.GetArticleLocalizationFromModel(article, model);

            articleLocalizationRepository.Insert(articleLocalization);
        }

        public void AddNewArticleLocalizationFromModel(ArticleModel model)
        {
            var article = _articleModelService.GetArticleFromModel(model);

            var articleLocalization = _articleModelService.GetArticleLocalizationFromModel(article, model);

            if (articleLocalizationRepository.Set()
                .Any(al => al.ArticleId == model.ArticleId && al.LanguageId == model.LanguageId))
            {
                throw new ArgumentException($"localization in language {model.LanguageId} for article {model.ArticleId} already exists", nameof(model));
            }

            articleLocalizationRepository.Insert(articleLocalization);
        }

        public void UpdateArticleLocalizationFromModel(ArticleModel model)
        {
            var article = _articleModelService.GetArticleFromModel(model);

            var originalArticleLocalization = articleLocalizationRepository.Set()
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

            articleLocalizationRepository.Update(originalArticleLocalization);
        }

        public void DeleteArticleLocalizationById(int articleId, int languageId)
        {
            var articleLocalization = articleLocalizationRepository.Set()
                .FirstOrDefault(al => al.ArticleId == articleId && al.LanguageId == languageId);

            if (articleLocalization == null)
            {
                throw new ArgumentException($"localization for article {articleId} in language {languageId} not found");
            }

            articleLocalizationRepository.Delete(articleLocalization);
        }

        #endregion
    }
}
