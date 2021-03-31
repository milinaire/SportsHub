using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class SportArticle
    {
        public int ArticleId { get; set; }
        public int LocationId { get; set; }
        public int TeamId { get; set; }
        public int ConferenceId { get; set; }
        public Article Article{ get; set; }
        public Location Location { get; set; }
        public Team Team { get; set; }
        public Conference Conference{ get; set; }
    }
}