using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class SportArticle
    {
        public int ArtcleId { get; set; }
        public int LocationId { get; set; }
        public int TeamId { get; set; }
        public int ConferencetId { get; set; }

        public ArtcleId ArtcleId { get; set; }
        public Location Location { get; set; }
        public Team Team { get; set; }
        public Conference Conference{ get; set; }
    }
}