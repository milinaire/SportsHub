﻿using Microsoft.EntityFrameworkCore;
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
    public class ArticleModelService: IArticleModelService
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IRepository<Language> _languageRepository;
        private readonly IRepository<Content> _contentRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Image> _imageRepository;

        public ArticleModelService(
            IRepository<Language> languageRepository,
            IRepository<Content> contentRepository,
            IRepository<Category> categoryRepository,
            IRepository<Image> imageRepository,
            IRepository<Article> articleRepository
            )
        {
            _languageRepository = languageRepository;
            _contentRepository = contentRepository;
            _categoryRepository = categoryRepository;
            _imageRepository = imageRepository;
            _articleRepository = articleRepository;
        }

        public Article GetArticleFromModel(ArticleModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (_articleRepository.Set().Any(a => a.Id == model.ArticleId))
            {
                throw new ArgumentException($"article id {model.ArticleId} is already taken", nameof(model));
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

        public ArticleModel GenerateArticleModel(Article article, int languageId)
        {
            var language = _languageRepository.Set().FirstOrDefault(l => l.Id == languageId);

            if (language == null)
            {
                throw new ArgumentException($"language {languageId} not found", nameof(language));
            }

            return this.GetArticleModel(article, language);
        }
        
    }
}
