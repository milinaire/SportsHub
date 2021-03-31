using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class BannerLocalization
    {
        public string Headline { get; set; }
        public int BannerId { get; set; }
        public int LanguageId { get; set; }

        public Banner Banner { get; set; }
        public Language Language { get; set; }
    }
}
