using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class ContactUsLocalizationn
    {
        public string Adress { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Headline { get; set; }
        public int SectionId { get; set; }
        public int LanguageId { get; set; }
        public CompanyInfoSection CompanyInfoSections { get; set; }
        public Language Language { get; set; }
    }
}
