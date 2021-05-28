using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class ContactUsLocalization : NoIdDBEntity
    {
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Headline { get; set; }
        public int SectionId { get; set; }
        public int LanguageId { get; set; }
        public virtual CompanyInfoSection CompanyInfoSection { get; set; }
        public virtual Language Language { get; set; }
    }
}
