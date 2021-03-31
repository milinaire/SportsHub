using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Survey
    {
        public int Id { get; set; }
        public bool Ispublished { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public bool IsClosed { get; set; }
        public IEnumerable <SurveyOptions> SurveyOptions { get; set; }

        public IEnumerable<SurveyLocalization> SurveyLocalizations { get; set; }
    }
}
