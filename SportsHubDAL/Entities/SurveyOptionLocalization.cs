using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class SurveyOptionLocalization : NoIdDBEntity
    {
        public string Option { get; set; }
        public int SurveyOptionId { get; set; }
        public int LanguageId { get; set; }
        public virtual SurveyOptions SurveyOption { get; set; }
        public virtual Language Language { get; set; }
    }
}
