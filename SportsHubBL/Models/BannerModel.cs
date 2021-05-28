using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Models
{
    public class BannerModel
    {
        public int BannerId { get; set; }
        public int LanguageId { get; set; }
        public int ?CategoryId { get; set; }
        public bool IsPublished { get; set; }
        public bool IsClosed { get; set; }
        public int? ImageId { get; set; }
        public string ImageUri { get; set; }
        public string Headline { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
