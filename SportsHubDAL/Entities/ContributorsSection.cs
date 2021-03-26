using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class ContributorsSection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Show { get; set; }
        public IEnumerable<ContributorsSectionsTranslation> ContributorsSectionsTranslations { get; set; }
    }
}
