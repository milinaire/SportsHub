using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Language: IDBEntity
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<SurveyLocalization> SurveyLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<SurveyOptionLocalization> SurveyOptionLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<BannerLocalization> BannerLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<PredefinedBannerLocalization> PredefinedBannerLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Term> Terms { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Privacy> Privacies { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<NewsLetterLocalization> NewsLetterLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<CompanyInfoLocalization> CompanyInfoLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<ContributorsLocalization> ContributorsLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<ContributorsSectionsLocalization> ContributorsSectionsLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<DeletableInfoSectionsLocalization> DeletableInfoSectionsLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<ContactUsLocalization> ContactUsLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<AboutSportHubLocalization> AboutSportHubLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<AdvertisingLocalization> AdvertisingLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<TeamLocalization> TeamLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<ConferenceLocalization> ConferenceLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<CategoryLocalization> CategoryLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<PhotoOfTheDayLocalization> PhotoOfTheDayLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<VideoLocalization> VideoLocalizations { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<ArticleLocalization> ArticleLocalizations { get; set; }
    }
}
