using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class CategoryAd : NoIdDBEntity
    {
        public int Opened { get; set; }
        public int Displayed { get; set; }
        public int CategoryId { get; set; }
        public int AdvertisingId { get; set; }
        public virtual Advertising Advertising { get; set; }
        public virtual Category Category { get; set; }
    }
}
