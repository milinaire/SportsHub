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
        public IEnumerable<BannerLocalization> BannerLocalizations { get; set; }
        public IEnumerable<PredefinedBannerLocalization> PredefinedBannerLocalization { get; set; }
        public IEnumerable<Term> Terms { get; set; }
        public IEnumerable<Privacy> Privacies { get; set; }
        public IEnumerable<NewsLetterTranslation> NewsLetterTranslations { get; set; }
        public IEnumerable<CompanyInfoTranslation> CompanyInfoTranslations { get; set; }
        public IEnumerable<ContributorsTranslation> ContributorsTranslations { get; set; }
        public IEnumerable<ContributorsSectionsTranslation> ContributorsSectionsTranslations { get; set; }
        public IEnumerable<DeletableInfoSectionsTranslation> DeletableInfoSectionsTranslations { get; set; }
        public IEnumerable<ContactUsTranslation> ContactUsTranslations { get; set; }
        public IEnumerable<AboutSportHubTranslation> AboutSportHubTranslations { get; set; }
    }
}
