using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Votes : NoIdDBEntity
    {
        public int OptionId { get; set; }
        public string UserId { get; set; }

        public virtual SurveyOptions SurveyOptions { get; set; }
        public virtual ApplicationUser User { get; set; }
        
    }
}