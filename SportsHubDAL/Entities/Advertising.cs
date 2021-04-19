using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Advertising : IDBEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public virtual Image Image { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual IEnumerable<AdvertisingLocalization> AdvertisingLocalizations { get; set; }
        public virtual IEnumerable<CategoryAd> CategoryAds { get; set; }
    }
}
