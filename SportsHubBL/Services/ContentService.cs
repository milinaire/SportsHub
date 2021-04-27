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

namespace SportsHubBL.Services
{
    public class ContentService : IContentService
    {
        private readonly IRepository<Content> _contentRepository;
        private readonly IRepository<Video> _videoRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Views> _viewsRepository;
        private readonly IRepository<Article> _articleRepository;

        public ContentService(
            IRepository<Content> contentRepository,
            IRepository<Video> videoRepository,
            IRepository<Comment> commentRepository,
            IRepository<Views> viewsRepository,
            IRepository<Article> articleRepository
            )
        {
            _contentRepository = contentRepository;
            _videoRepository = videoRepository;
            _commentRepository = commentRepository;
            _viewsRepository = viewsRepository;
            _articleRepository = articleRepository;
        }

        public void AddContentFromModel(ContentModel model, int itemId, ContentItemType itemType)
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

        public ContentModel GetContent(int itemId, ContentItemType itemType)
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

            return new ContentModel
            {
                Id = item.Id,
                ContentItemId = item.Id,
                Type = itemType,
                IsPublished = content.IsPublished,
                Datetime = content.Datetime,
                ShowComments = content.ShowComments
            };
        }

        public void UpdateContentFromModel(ContentModel model, int itemId, ContentItemType itemType)
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

            item.Content = content;

            repository.Update(item);
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
                ContentItemType.VideoContent => (IRepository<IDBEntityWithContent>)_videoRepository,
                ContentItemType.CommentContent => (IRepository<IDBEntityWithContent>)_commentRepository,
                ContentItemType.ArticleContent => (IRepository<IDBEntityWithContent>)_articleRepository,
                ContentItemType.ViewContent => (IRepository<IDBEntityWithContent>)_viewsRepository,
                _ => throw new ArgumentException("invalid enum", nameof(itemType))
            };
        }
    }
}
