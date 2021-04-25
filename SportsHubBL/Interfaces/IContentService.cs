using SportsHubBL.Enums;
using SportsHubBL.Models;

namespace SportsHubBL.Interfaces
{
    public interface IContentService
    {
        public ContentModel GetContent(int itemId, ContentItemType itemType);

        public void AddContentFromModel(ContentModel model, int itemId, ContentItemType itemType);

        public void UpdateContentFromModel(ContentModel model, int itemId, ContentItemType itemType);

        public void DeleteContent(int contentId);

        public void DeleteContentFromItem(int itemId, ContentItemType itemType);
    }
}