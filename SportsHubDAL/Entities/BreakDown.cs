using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class BreakDown
    {
        public int Id { get; set; }
        public bool Show { get; set; }
        public int ConferenceId { get; set; }
        public int CategoryId { get; set; }
        public int TeamId { get; set; }

        public Conference Conference { get; set; }
        public Category Category { get; set; }
        public Team Team{ get; set; }
     
    }
}