using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Team: IDBEntity
    {
        public int Id { get; set; }
        public virtual Conference Conference { get; set; }
        public virtual Location Location { get; set; }
        public virtual Image Image { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public bool Show { get; set; }
        public virtual IEnumerable<FollowedTeam> FollowedTeams { get; set; }
        public virtual IEnumerable<BreakDown> BreakDowns { get; set; }
        public virtual IEnumerable<TeamLocalization> TeamLocalizations { get; set; }
        public virtual IEnumerable<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        public virtual IEnumerable<SportArticle> SportArticles { get; set; }
    }
}
