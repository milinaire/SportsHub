using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class FollowedTeam : NoIdDBEntity
    {
        public int TeamId { get; set; }
        public string UserId { get; set; }
        public virtual Team Team { get; set; }
        public virtual ApplicationUser User { get; set; }
        
    }
}