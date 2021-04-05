using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsHubDAL.Interfaces;

namespace SportsHubDAL.Entities
{
    public class Conference : DBEntity
    {
        public int Id { get; set; }
        public bool Show { get; set; }
        public Category Category { get; set; }
        public IEnumerable<BreakDown> BreakDowns { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<ConferenceLocalization> ConferenceLocalizations { get; set; }
        public IEnumerable<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        public IEnumerable<SportArticle> SportArticle { get; set; }
    }
}
