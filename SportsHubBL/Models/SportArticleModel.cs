using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Models
{
    public class SportArticleModel : ArticleModel
    {
        public SportArticleModel(ArticleModel articleModel)
        {
            if (articleModel == null)
            {
                throw new ArgumentNullException(nameof(articleModel));
            }

            ArticleId = articleModel.ArticleId;
            LanguageId = articleModel.LanguageId;
            ImageId = articleModel.ImageId;
            ImageUri = articleModel.ImageUri;
            CategoryId = articleModel.CategoryId;
            ContentId = articleModel.ContentId;
            IsPublished = articleModel.IsPublished;
            DatePublished = articleModel.DatePublished;
            ShowComments = articleModel.ShowComments;
            Headline = articleModel.Headline;
            Text = articleModel.Text;
            Caption = articleModel.Caption;
            Alt = articleModel.Alt;
        }

        public int LocationId { get; set; }

        public string LocationUri { get; set; }

        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public int ConferenceId { get; set; }

        public string ConferenceName { get; set; }
    }
}
