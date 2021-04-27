using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Category : IDBEntity
    {
        public int Id { get; set; }
        public bool Show { get; set; }
        public bool IsEditable { get; set; }

        public virtual IEnumerable<Conference> Conferences { get; set; }
        public virtual IEnumerable<BreakDown> BreakDowns { get; set; }
        public virtual IEnumerable<CategoryAd> CategoryAds { get; set; }
        public virtual IEnumerable<CategoryPartner> CategoryPartners { get; set; }
        public virtual IEnumerable<CategoryLocalization> CategoryLocalizations { get; set; }
        public virtual IEnumerable<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        public virtual IEnumerable<Banner> Banners { get; set; }
    }
}
