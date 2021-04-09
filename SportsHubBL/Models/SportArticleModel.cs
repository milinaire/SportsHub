using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Models
{
    public class SportArticleModel : ArticleModel
    {
        public int LocationId { get; set; }

        public string LocationUri { get; set; }

        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public int ConferenceId { get; set; }

        public string ConferenceName { get; set; }
    }
}
