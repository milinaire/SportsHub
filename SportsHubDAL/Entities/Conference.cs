using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SportsHubDAL.Entities
{
    public class Conference: IDBEntity
    {
        public int Id { get; set; }
        public bool Show { get; set; }
        public virtual Category Category { get; set; }
        public virtual IEnumerable<BreakDown> BreakDowns { get; set; }
        public virtual IEnumerable<Team> Teams { get; set; }
        public virtual IEnumerable<ConferenceLocalization> ConferenceLocalizations { get; set; }
        public virtual IEnumerable<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        public virtual IEnumerable<SportArticle> SportArticles { get; set; }
    }
}
