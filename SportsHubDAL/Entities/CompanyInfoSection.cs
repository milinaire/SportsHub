using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SportsHubDAL.Entities
{
    public class CompanyInfoSection : IDBEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Show { get; set; }
        public virtual IEnumerable<DeletableInfoSectionsLocalization> DeletableInfoSectionsLocalizations { get; set; }
        public virtual IEnumerable<ContactUsLocalization> ContactUsLocalizations { get; set; }
        public virtual IEnumerable<AboutSportHubLocalization> AboutSportHubTLocalizations { get; set; }
    }
}
