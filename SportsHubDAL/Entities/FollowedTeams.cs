using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Votes
    {
        public int TeamId { get; set; }
        public int UserId { get; set; }

        public Team Team { get; set; }
        public User User { get; set; }
        
    }
}