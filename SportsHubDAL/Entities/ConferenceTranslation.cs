using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class ConferenceTranslation
    {
        public string Name { get; set; }
        
        public int ConferenceId { get; set; }
        public int LanguageId { get; set; }
        public Conference Conference { get; set; }
        public Language Language { get; set; }
    }
}
