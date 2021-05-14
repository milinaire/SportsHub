using SportsHubBL.Enums;
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
using SportsHubDAL.Data;
using SportsHubBL.Common;

namespace SportsHubBL.Services
{
    public class ContentService : IContentService
    {
        private readonly IRepository<Content> _contentRepository;
        private readonly VideoRepository _videoRepository;
        private readonly CommentRepository _commentRepository;
        private readonly ViewsRepository _viewsRepository;
        private readonly ArticleRepository _articleRepository;

        public ContentService(
            IRepository<Content> contentRepository,
            VideoRepository videoRepository,
            CommentRepository commentRepository,
            ViewsRepository viewsRepository,
            ArticleRepository articleRepository
            )
        {
            _contentRepository = contentRepository;
            _videoRepository = videoRepository;
            _commentRepository = commentRepository;
            _viewsRepository = viewsRepository;
            _articleRepository = articleRepository;
        }

        public Content AddContentFromModel(ContentModel model, int itemId, ContentItemType itemType)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var repository = GetRepository(itemType);

            var content = GetContentFromModel(model);

            var item = repository.GetById(itemId);

            item.Content = content;

            repository.Insert(item);

            return content;
        }

        public void DeleteContent(int contentId)
        {
            var content = _contentRepository.GetById(contentId);

            if (content == null)
            {
                throw new Exception($"content {contentId} not found");
            }

            _contentRepository.Delete(content);
        }

        public void DeleteContentFromItem(int itemId, ContentItemType itemType)
        {
            var repository = GetRepository(itemType);

            var item = repository.Set().Include(i => i.Content).FirstOrDefault(i => i.Id == itemId);

            if (item == null)
            {
                throw new Exception($"item with id {itemId} not found");
            }

            DeleteContent(item.Content.Id);
        }

        public IEnumerable<Content> GetAllContent()
        {
            return _contentRepository.Set().ToList();
        }

        public ContentModel GetContentModel(int itemId, ContentItemType itemType)
        {
            var repository = GetRepository(itemType);

            var item = repository.Set().Include(i => i.Content).FirstOrDefault(i => i.Id == itemId);

            if (item == null)
            {
                throw new Exception($"item {itemId} not found");
            }

            var content = item.Content;

            if (content == null)
            {
                throw new Exception($"no content for item {itemId}");
            }

            var model = GetBaseContentModel(content);

            model.ContentItemId = itemId;
            model.Type = itemType;

            return model;
        }

        public ContentModel GetBaseContentModel(Content content)
        {
            return new ContentModel
            {
                Id = content.Id,
                IsPublished = content.IsPublished,
                Datetime = content.Datetime,
                ShowComments = content.ShowComments
            };
        }

        public Content UpdateContentFromModel(ContentModel model, int itemId, ContentItemType itemType)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var repository = GetRepository(itemType);

            var item = repository.Set().Include(i => i.Content).FirstOrDefault(i => i.Id == itemId);

            if (item == null)
            {
                throw new Exception($"item with id {itemId} not found");
            }

            var content = item.Content;

            if (content == null)
            {
                throw new Exception($"item {itemId} has no content to update");
            }

            var newContent = GetContentFromModel(model);

            content.Datetime = newContent.Datetime;
            content.IsPublished = newContent.IsPublished;
            content.ShowComments = newContent.ShowComments;

            item.Content = content;

            repository.Update(item);

            return content;
        }

        private Content GetContentFromModel(ContentModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new Content
            {
                Id = model.Id,
                IsPublished = model.IsPublished,
                Datetime = model.Datetime,
                ShowComments = model.ShowComments
            };
        }

        private IRepository<IDBEntityWithContent> GetRepository(ContentItemType itemType)
        {
            return itemType switch
            {
                ContentItemType.VideoContent => _videoRepository,
                ContentItemType.CommentContent => _commentRepository,
                ContentItemType.ArticleContent => _articleRepository,
                ContentItemType.ViewContent => _viewsRepository,
                _ => throw new ArgumentException("invalid enum", nameof(itemType))
            };
        }

        public Content GetContentById(int contentId)
        {
            return _contentRepository.GetById(contentId);
        }
    }
}
