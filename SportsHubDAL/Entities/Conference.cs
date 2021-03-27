using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Conference
    {
        public int Id { get; set; }
        public bool Show { get; set; }

        public Category Category { get; set; }

        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<ConferenceTranslation> ConferenceTranslations { get; set; }
    }
}
