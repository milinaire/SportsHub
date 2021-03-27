using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public Conference Conference { get; set; }
        public Location Location { get; set; }
        public Image Image { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Show { get; set; }
        public IEnumerable<TeamTranslation> TeamTranslations { get; set; }
    }
}
