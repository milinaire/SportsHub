using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class BannerLocalization : NoIdDBEntity
    {
        public string Headline { get; set; }
        public int BannerId { get; set; }
        public int LanguageId { get; set; }

        public virtual Banner Banner { get; set; }
        public virtual Language Language { get; set; }
    }
}
