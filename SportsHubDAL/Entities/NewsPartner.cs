using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class NewsPartner : IDBEntity
    {
        public int Id { get; set; }
        public virtual AllowedPartner AllowedPartners { get; set; }
        public bool IsActive { get; set; }
        public string ApiKey { get; set; }
        public string DefaultSources { get; set; }
        public virtual IEnumerable<CategoryPartner> CategoryPartners { get; set; }
    }
}
