using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class SurveyOptions : IDBEntity
    {
        public int Id { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual IEnumerable<Votes> Votes { get; set; }
        public virtual IEnumerable<SurveyOptionLocalization> SurveyOptionLocalizations { get; set; }
    }
}
