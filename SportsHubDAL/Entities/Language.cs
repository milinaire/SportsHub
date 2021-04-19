using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Language: IDBEntity
    {
        public int Id { get; set; }
        public string LanguageName { get; set; }
        public virtual IEnumerable<SurveyLocalization> SurveyLocalizations { get; set; }
        public virtual IEnumerable<SurveyOptionLocalization> SurveyOptionLocalizations { get; set; }
        public virtual IEnumerable<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        public virtual IEnumerable<BannerLocalization> BannerLocalizations { get; set; }
        public virtual IEnumerable<PredefinedBannerLocalization> PredefinedBannerLocalizations { get; set; }
        public virtual IEnumerable<Term> Terms { get; set; }
        public virtual IEnumerable<Privacy> Privacies { get; set; }
        public virtual IEnumerable<NewsLetterLocalization> NewsLetterLocalizations { get; set; }
        public virtual IEnumerable<CompanyInfoLocalization> CompanyInfoLocalizations { get; set; }
        public virtual IEnumerable<ContributorsLocalization> ContributorsLocalizations { get; set; }
        public virtual IEnumerable<ContributorsSectionsLocalization> ContributorsSectionsLocalizations { get; set; }
        public virtual IEnumerable<DeletableInfoSectionsLocalization> DeletableInfoSectionsLocalizations { get; set; }
        public virtual IEnumerable<ContactUsLocalization> ContactUsLocalizations { get; set; }
        public virtual IEnumerable<AboutSportHubLocalization> AboutSportHubLocalizations { get; set; }
        public virtual IEnumerable<AdvertisingLocalization> AdvertisingLocalizations { get; set; }
        public virtual IEnumerable<TeamLocalization> TeamLocalizations { get; set; }
        public virtual IEnumerable<ConferenceLocalization> ConferenceLocalizations { get; set; }
        public virtual IEnumerable<CategoryLocalization> CategoryLocalizations { get; set; }
        public virtual IEnumerable<PhotoOfTheDayLocalization> PhotoOfTheDayLocalizations { get; set; }
        public virtual IEnumerable<VideoLocalization> VideoLocalizations { get; set; }
        public virtual IEnumerable<ArticleLocalization> ArticleLocalizations { get; set; }
    }
}
