using SportsHubBL.Enums;
using SportsHubBL.Models;
using SportsHubDAL.Entities;
using System.Collections.Generic;

namespace SportsHubBL.Interfaces
{
    public interface IContentService
    {
        public Content GetContentById(int contentId);

        public IEnumerable<Content> GetAllContent();

        public ContentModel GetBaseContentModel(Content content);

        public ContentModel GetContentModel(int itemId, ContentItemType itemType);

        public Content AddContentFromModel(ContentModel model, int itemId, ContentItemType itemType);

        public Content UpdateContentFromModel(ContentModel model, int itemId, ContentItemType itemType);

        public void DeleteContent(int contentId);

        public void DeleteContentFromItem(int itemId, ContentItemType itemType);
    }
}