using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Language: NoIdDBEntity
    {
        public int Id { get; set; }
        public string language { get; set; }
        public IEnumerable<SurveyLocalization> SurveyLocalizations { get; set; }
        public IEnumerable<SurveyOptionLocalization> SurveyOptionLocalizations { get; set; }
        public IEnumerable<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        public IEnumerable<BannerLocalization> BannerLocalizations { get; set; }
        public IEnumerable<PredefinedBannerLocalization> PredefinedBannerLocalizations { get; set; }
        public IEnumerable<Term> Terms { get; set; }
        public IEnumerable<Privacy> Privacies { get; set; }
        public IEnumerable<NewsLetterLocalization> NewsLetterLocalizations { get; set; }
        public IEnumerable<CompanyInfoLocalization> CompanyInfoLocalizations { get; set; }
        public IEnumerable<ContributorsLocalization> ContributorsLocalizations { get; set; }
        public IEnumerable<ContributorsSectionsLocalization> ContributorsSectionsLocalizations { get; set; }
        public IEnumerable<DeletableInfoSectionsLocalization> DeletableInfoSectionsLocalizations { get; set; }
        public IEnumerable<ContactUsLocalizationn> ContactUsLocalizations { get; set; }
        public IEnumerable<AboutSportHubLocalization> AboutSportHubLocalizations { get; set; }
        public IEnumerable<AdvertisingLocalization> AdvertisingLocalizations { get; set; }
        public IEnumerable<TeamLocalization> TeamLocalizations { get; set; }
        public IEnumerable<ConferenceLocalization> ConferenceLocalizations { get; set; }
        public IEnumerable<CategoryLocalization> CategoryLocalizations { get; set; }
        public IEnumerable<PhotoOfTheDayLocalization> PhotoOfTheDayLocalizations { get; set; }
        public IEnumerable<VideoLocalization> VideoLocalizations { get; set; }
        public IEnumerable<ArticleLocalization> ArticleLocalizations { get; set; }
    }
}
