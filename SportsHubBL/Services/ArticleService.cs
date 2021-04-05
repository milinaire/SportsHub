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
        private readonly IRepository<Article> articleRepository;
        private readonly IRepository<Language> languageRepository;
        private readonly IRepository<Content> contentRepository;
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Image> imageRepository;
        private readonly IRepository<ArticleLocalization> articleLocalizationRepository;

        public ArticleService(
            IRepository<Article> articleRepository,
            IRepository<Language> languageRepository,
            IRepository<Content> contentRepository,
            IRepository<Category> categoryRepository,
            IRepository<ArticleLocalization> articleLocalizationRepository,
            IRepository<Image> imageRepository
            )
        {
            this.articleRepository = articleRepository;
            this.languageRepository = languageRepository;
            this.contentRepository = contentRepository;
            this.categoryRepository = categoryRepository;
            this.articleLocalizationRepository = articleLocalizationRepository;
            this.imageRepository = imageRepository;
        }

        public void AddArticleFromModel(ArticleModel model)
        {
            var article = GetArticleFromModel(model);

            var articleLocalization = GetArticleLocalizationFromModel(article, model);

            articleRepository.Insert(article);

            articleLocalizationRepository.Insert(articleLocalization);
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

            var article = GetArticleFromModel(model);


            originalArticle.Image = article.Image;
            originalArticle.Category = article.Category;
            originalArticle.Content = article.Content;

            articleRepository.Update(originalArticle);
        }

        public ArticleModel GetArticleModel(Article article, Language language)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            if (article.Content == null
                || article.Category == null
                || article.Image == null
                || article.ArticleLocalizations == null)
            {
                article = articleRepository.Set()
                    .Include(a => a.Content)
                    .Include(a => a.Category)
                    .Include(a => a.Image)
                    .Include(a => a.ArticleLocalizations)
                    .FirstOrDefault(a => a == article);

                if (article == null)
                {
                    throw new ArgumentNullException(nameof(article));
                }
            }

            var articleLocalization = article.ArticleLocalizations.FirstOrDefault(at => at.Language == language);

            if (articleLocalization == null)
            {
                throw new ArgumentException("can\'t find localization for article");
            }

            return new ArticleModel
            {
                ArticleId = article.Id,
                LanguageId = language.Id,
                ImageId = article.Image.Id,
                ImageUri = article.Image.Uri,
                CategoryId = article.Category.Id,
                ContentId = article.Content.Id,
                IsPublished = article.Content.IsPublished,
                DatePublished = article.Content.Datetime,
                ShowComments = article.Content.ShowComments,
                Headline = articleLocalization.Headline,
                Text = articleLocalization.Text,
                Caption = articleLocalization.Caption,
                Alt = articleLocalization.Alt
            };
        }

        private Article GetArticleFromModel(ArticleModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (articleRepository.Set().Any(a => a.Id == model.ArticleId))
            {
                throw new ArgumentException($"article id {model.ArticleId} is already taken", nameof(model));
            }

            var category = categoryRepository.Set().FirstOrDefault(c => c.Id == model.CategoryId);

            var image = imageRepository.Set().FirstOrDefault(i => i.Id == model.ImageId);

            if (image == null && model.ImageUri != default)
            {
                image = new Image
                {
                    Uri = model.ImageUri
                };
            }

            var content = contentRepository.Set().FirstOrDefault(c => c.Id == model.ContentId);

            if (content == null && (model.DatePublished != null || model.IsPublished != null || model.ShowComments != null))
            {
                content = new Content
                {
                    IsPublished = (bool)model.IsPublished,
                    Datetime = (DateTime)model.DatePublished,
                    ShowComments = (bool)model.ShowComments
                };
            }

            return new Article
            {
                Image = image,
                Category = category,
                Content = content
            };
        }

        private ArticleLocalization GetArticleLocalizationFromModel(Article article, ArticleModel model)
        {
            var language = languageRepository.Set().FirstOrDefault(l => l.Id == model.LanguageId);

            if (language == null)
            {
                throw new ArgumentException($"can\'t find language {model.LanguageId}", nameof(model));
            }

            return new ArticleLocalization
            {
                Article = article,
                Language = language,
                Headline = model.Headline,
                Text = model.Text,
                Caption = model.Caption,
                Alt = model.Alt
            };
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

            return contentRepository.Set().FirstOrDefault(c => c.Article == article);
        }

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

        public IEnumerable<Article> GetArticlesByCategory(int categoryId, int count)
        {
            var category = categoryRepository.Set().FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                throw new ArgumentException("category was null", nameof(categoryId));
            }

            if (count <= 0)
            {
                throw new ArgumentException("unexpected count", nameof(count));
            }

            return articleRepository.Set().Where(a => a.Category == category).Take(count);
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

        public ArticleModel GenerateArticleModel(Article article, int languageId)
        {
            var language = languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new ArgumentException("language was null", nameof(language));
            }

            return this.GetArticleModel(article, language);
        }

        public void AddNewArticleLocalizationFromModel(ArticleModel model)
        {
            var article = GetArticleFromModel(model);

            var articleLocalization = GetArticleLocalizationFromModel(article, model);

            if (articleLocalizationRepository.Set()
                .Any(al => al.ArticleId == model.ArticleId && al.LanguageId == model.LanguageId))
            {
                throw new ArgumentException($"localization in language {model.LanguageId} for article {model.ArticleId} already exists", nameof(model));
            }

            articleLocalizationRepository.Insert(articleLocalization);
        }

        public void UpdateArticleLocalizationFromModel(ArticleModel model)
        {
            var article = GetArticleFromModel(model);

            var originalArticleLocalization = articleLocalizationRepository.Set()
                .FirstOrDefault(al => al.ArticleId == article.Id && al.LanguageId == model.LanguageId);

            if (originalArticleLocalization == null)
            {
                throw new ArgumentException($"no previous localization in language {model.LanguageId} of article {model.ArticleId}", nameof(model));
            }

            var newArticleLocalization = GetArticleLocalizationFromModel(article, model);

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
    }
}
