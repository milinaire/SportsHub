using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class AllowedPartner : IDBEntity
    { 
        public int Id { get;set;}
        public string Name{ get; set; }
        public virtual IEnumerable<NewsPartner> NewsPartners { get; set; }
    }
}
