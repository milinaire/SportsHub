using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class NewsPartner
    {
        public int Id { get; set; }
        public AllovedPartner AllovedPartners { get; set; }
        public bool IsActive { get; set; }
        public string ApiKey { get; set; }
        public string DefoultSourses { get; set; }
        public IEnumerable<CategoryPartner> CategoryPartners { get; set; }
    }
}
