using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class SurveyOptions
    {
        public int Id { get; set; }
        public Survey Survey { get; set; }
        public IEnumerable<Votes> Votes { get; set; }
        public List<SurveyOptionLocalization> SurveyOptionLocalizations { get; set; }
    }
}
