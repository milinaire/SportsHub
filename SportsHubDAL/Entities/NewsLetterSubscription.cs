using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class NewsLetterSubscription
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool All { get; set; }

        public Category Category{ get; set; }
        public Conference Conference{ get; set; }
        public Team Team{ get; set; }
        public Language Language{ get; set; }
     
    }
}