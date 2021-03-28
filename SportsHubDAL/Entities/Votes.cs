using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Votes
    {
        public int OptionId { get; set; }
        public int UserId { get; set; }

        public SurveyOptions SurveyOptions { get; set; }
        public User User { get; set; }
        
    }
}