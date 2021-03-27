using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class TeamTranslation
    {
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public int TeamId { get; set; }
        public int LanguageId { get; set; }
        public Team Team { get; set; }
        public Language Language { get; set; }
    }
}
