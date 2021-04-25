using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class CategoryPartner : NoIdDBEntity
    {
        public int CategoryId { get; set; }
        public int NewsPartnerId { get; set; }
        public string Sourses { get; set; }
        public virtual NewsPartner NewsPartner { get; set; }
        public virtual Category Category { get; set; }
    }
}
