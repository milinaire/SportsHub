using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class TeamLocalization : NoIdDBEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeamId { get; set; }
        public int LanguageId { get; set; }
        public virtual Team Team { get; set; }
        public virtual Language Language { get; set; }
    }
}
