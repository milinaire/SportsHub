using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class PredefinedBanner : IDBEntity
    {
        public int Id { get; set; }
        public bool Show { get; set; }
        public virtual Image Image { get; set; }
        public virtual IEnumerable<PredefinedBannerLocalization> PredefinedBannerLocalization { get; set; }
    }
}
