using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Category : IDBEntity
    {
        public int Id { get; set; }
        public bool Show { get; set; }
        public bool IsEditable { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Conference> Conferences { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<BreakDown> BreakDowns { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<CategoryAd> CategoryAds { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<CategoryPartner> CategoryPartners { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<CategoryLocalization> CategoryLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Banner> Banners { get; set; }
    }
}
