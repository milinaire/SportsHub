using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class ContributorsSection : IDBEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Show { get; set; }
        public virtual IEnumerable<ContributorsSectionsLocalization> ContributorsSectionsLocalizations { get; set; }
    }
}
