using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsHubDAL.Interfaces;

namespace SportsHubDAL.Entities
{
    public class TeamLocalization : DBEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
        public int LanguageId { get; set; }
        public Team Team { get; set; }
        public Language Language { get; set; }
    }
}
