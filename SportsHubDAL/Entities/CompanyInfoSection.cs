using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SportsHubDAL.Entities
{
    public class CompanyInfoSection
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Show { get; set; }
        public IEnumerable<DeletableInfoSectionsLocalization> DeletableInfoSectionsTranslations { get; set; }
        public IEnumerable<ContactUsLocalizationn> ContactUsTranslations { get; set; }
        public IEnumerable<AboutSportHubLocalization> AboutSportHubTranslations { get; set; }
    }
}
