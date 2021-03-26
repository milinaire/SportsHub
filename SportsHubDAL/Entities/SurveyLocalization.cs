using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SportsHubDAL.Entities
{
    public class SurveyLocalization
    {
        public string Headline { get; set; }
        public int SurveyId { get; set; }
        public int LanguageId { get; set; }

        
        public  Survey Survey { get; set; }
        
        public  Language Language { get; set; }
    }

}
