using Microsoft.EntityFrameworkCore;
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
    public class ArticleModelService : IArticleModelService
    {
        private readonly INoIdRepository<Article> _articleRepository;
        private readonly INoIdRepository<Language> _languageRepository;
        private readonly INoIdRepository<Content> _contentRepository;
        private readonly INoIdRepository<Category> _categoryRepository;
        private readonly INoIdRepository<Image> _imageRepository;
        private readonly IRepository<MainArticle> _mainArticleRepository;

        public ArticleModelService(
            INoIdRepository<Language> languageRepository,
            INoIdRepository<Content> contentRepository,
            INoIdRepository<Category> categoryRepository,
            INoIdRepository<Image> imageRepository,
            INoIdRepository<Article> articleRepository, 
            IRepository<MainArticle> mainArticleRepository
            )
        {
            _languageRepository = languageRepository;
            _contentRepository = contentRepository;
            _categoryRepository = categoryRepository;
            _imageRepository = imageRepository;
            _articleRepository = articleRepository;
            _mainArticleRepository = mainArticleRepository;
        }

        public Article GetArticleFromModel(ArticleModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var category = _categoryRepository.Set().FirstOrDefault(c => c.Id == model.CategoryId);

            var image = _imageRepository.Set().FirstOrDefault(i => i.Id == model.ImageId);

            if (image == null && model.ImageUri != default)
            {
                image = new Image
                {
                    Uri = model.ImageUri
                };
            }

            var content = _contentRepository.Set().FirstOrDefault(c => c.Id == model.ContentId);

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
                Id = model.ArticleId,
                Image = image,
                Category = category,
                Content = content
            };
        }

        public ArticleLocalization GetArticleLocalizationFromModel(Article article, ArticleModel model)
        {
            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == model.LanguageId);

            if (language == null)
            {
                throw new Exception($"can\'t find language {model.LanguageId}");
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

        public ArticleModel GetLocalizedArticleModel(Article article, Language language)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            var model = FormBaseArticleModel(article);

            try
            {
                model = LocalizeArticleModel(model, article, language);
            }
            catch (Exception e)
            {
                model.Caption = e.Message;
            }

            return model;
        }

        private ArticleModel LocalizeArticleModel(ArticleModel model, Article article, Language language)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            if (article.ArticleLocalizations == null)
            {
                article = _articleRepository.Set().Include(a => a.ArticleLocalizations).FirstOrDefault(a => a == article);
            }

            model.LanguageId = language.Id;

            var articleLocalization = article.ArticleLocalizations.FirstOrDefault(at => at.Language == language);

            if (articleLocalization == null)
            {
                throw new Exception($"Localization in language {language.Id} for article {article.Id} not found");
            }
            model.Headline = articleLocalization.Headline;
            model.Text = articleLocalization.Text;
            model.Caption = articleLocalization.Caption;
            model.Alt = articleLocalization.Alt;

            return model;
        }

        private ArticleModel FormBaseArticleModel(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            if (article.Content == null
                || article.Category == null
                || article.Image == null
                || article.ArticleLocalizations == null)
            {
                article = _articleRepository.Set()
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

            return new ArticleModel
            {
                ArticleId = article.Id,
                ImageId = article.Image?.Id,
                ImageUri = article.Image?.Uri,
                CategoryId = article.Category?.Id,
                ContentId = article.Content?.Id,
                IsPublished = article.Content?.IsPublished,
                DatePublished = article.Content?.Datetime,
                ShowComments = article.Content?.ShowComments,
            };
        }

        public ArticleModel GetLocalizedArticleModel(Article article, int languageId)
        {
            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new Exception($"language {languageId} not found");
            }

            return this.GetLocalizedArticleModel(article, language);
        }

        public MainArticleModel GenerateMainArticleModel(MainArticle mainArticle)
        {
            if (mainArticle == null)
            {
                throw new ArgumentNullException(nameof(mainArticle));
            }

            if (mainArticle.Article == null)
            {
                mainArticle = _mainArticleRepository.Set().Include(ma => ma.Article).FirstOrDefault(ma => ma == mainArticle);
                if (mainArticle.Article == null)
                {
                    throw new Exception($"main article {mainArticle.Id} does not contain an article");
                }
            }

            return new MainArticleModel
            {
                Id = mainArticle.Id,
                ArticleId = mainArticle.Article.Id,
                Show = mainArticle.Show
            };
        }

        public ArticleModel GetBaseArticleModel(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            var model = FormBaseArticleModel(article);

            return model;
        }
    }
}
