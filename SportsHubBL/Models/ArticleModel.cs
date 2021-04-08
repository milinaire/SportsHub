using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Models
{
    public class ArticleModel
    {
        public int ArticleId { get; set; }

        public int LanguageId { get; set; }

        public int? ImageId { get; set; }

        public string ImageUri { get; set; }

        public int? CategoryId { get; set; }

        public int? ContentId { get; set; }

        public bool? IsPublished { get; set; }

        public DateTime? DatePublished { get; set; }

        public bool? ShowComments { get; set; }

        public string Headline { get; set; }

        public string Text { get; set; }

        public string Caption { get; set; }

        public string Alt { get; set; }
    }
}
