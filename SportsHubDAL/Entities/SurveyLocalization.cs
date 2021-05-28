using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SportsHubDAL.Interfaces;

namespace SportsHubDAL.Entities
{
    public class SurveyLocalization : NoIdDBEntity
    {
        public string Headline { get; set; }
        public int SurveyId { get; set; }
        public int LanguageId { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual Language Language { get; set; }
    }

}
