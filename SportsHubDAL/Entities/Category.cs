using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Category : DBEntity
    {
        public int Id { get; set; }
        public bool Show { get; set; }
        public bool IsEditable { get; set; }

        public IEnumerable<Conference> Conferences { get; set; }
        public IEnumerable<BreakDown> BreakDowns { get; set; }
        public IEnumerable<CategoryAd> CategoryAds { get; set; }
        public IEnumerable<CategoryPartner> CategoryPartners { get; set; }
        public IEnumerable<CategoryLocalization> CategoryLocalizations { get; set; }
        public IEnumerable<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        public IEnumerable<Banner> Banners { get; set; }
    }
}
