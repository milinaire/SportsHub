using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Survey : IDBEntity
    {
        public int Id { get; set; }
        public bool IsPublished { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public bool IsClosed { get; set; }
        public virtual IEnumerable<SurveyOptions> SurveyOptions { get; set; }
        public virtual IEnumerable<SurveyLocalization> SurveyLocalizations { get; set; }
    }
}
