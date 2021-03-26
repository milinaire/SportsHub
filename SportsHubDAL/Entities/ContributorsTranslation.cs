using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class ContributorsTranslation
    {
        public Language Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
