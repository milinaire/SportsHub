using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class PredefinedBanner
    {
        public int Id { get; set; }
        public bool Show { get; set; }
        public Image Image { get; set; }
        public IEnumerable<PredefinedBannerLocalization> PredefinedBannerLocalization { get; set; }
    }
}
