using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SportsHubDAL.Entities
{
    public class Term
    {
        public int Id { get; set; }
        public Language Language{ get; set; }
        public string Headline { get; set; }
        
        public string Text { get; set; }


    }
}
