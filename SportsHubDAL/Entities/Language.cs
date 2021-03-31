using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string language { get; set; }
        public IEnumerable<SurveyLocalization> SurveyLocalizations { get; set; }
        public IEnumerable<SurveyOptionLocalization> SurveyOptionLocalizations { get; set; }
        public IEnumerable<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        public IEnumerable<BannerLocalization> BannerLocalizations { get; set; }
        public IEnumerable<PredefinedBannerLocalization> PredefinedBannerLocalization { get; set; }
        public IEnumerable<Term> Terms { get; set; }
        public IEnumerable<Privacy> Privacies { get; set; }
        public IEnumerable<NewsLetterLocalization> NewsLetterTranslations { get; set; }
        public IEnumerable<CompanyInfoLocalization> CompanyInfoTranslations { get; set; }
        public IEnumerable<ContributorsLocalization> ContributorsTranslations { get; set; }
        public IEnumerable<ContributorsSectionsLocalization> ContributorsSectionsTranslations { get; set; }
        public IEnumerable<DeletableInfoSectionsLocalization> DeletableInfoSectionsTranslations { get; set; }
        public IEnumerable<ContactUsLocalizationn> ContactUsTranslations { get; set; }
        public IEnumerable<AboutSportHubLocalization> AboutSportHubTranslations { get; set; }
        public IEnumerable<AdvertisingLocalization> AdvertisingLocalizations { get; set; }
        public IEnumerable<TeamLocalization> TeamTranslations { get; set; }
        public IEnumerable<ConferenceLocalization> ConferenceTranslations { get; set; }
        public IEnumerable<CategoryLocalization> CategoryTranslations { get; set; }
        public IEnumerable<PhotoOfTheDayLocalization> PhotoOfTheDayLocalizations { get; set; }
        public IEnumerable<VideoLocalization> VideoTrasnlations { get; set; }
        public IEnumerable<ArticleLocalization> ArticleTranslations { get; set; }
    }
}
