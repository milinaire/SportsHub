using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class SurveyOptionLocalization
    {
        public string Option { get; set; }
        public int SurveyOptionId { get; set; }
        public int LanguageId { get; set; }
        public SurveyOptions SurveyOption { get; set; }
        public Language Language { get; set; }
    }
}
