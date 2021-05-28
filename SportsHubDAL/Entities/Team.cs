using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Team: IDBEntity
    {
        public int Id { get; set; }
        [JsonIgnore]
        public virtual Conference Conference { get; set; }
        [JsonIgnore]
        public virtual Location Location { get; set; }
        [JsonIgnore]
        public virtual Image Image { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public bool Show { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<FollowedTeam> FollowedTeams { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<BreakDown> BreakDowns { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<TeamLocalization> TeamLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<SportArticle> SportArticles { get; set; }
    }
}
