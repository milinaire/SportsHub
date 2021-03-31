using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class AllovedPartner { 
        public int Id { get;set;}
        public  string Name{ get; set; }
        public IEnumerable<NewsPartner> NewsPartners { get; set; }
    }
}
