using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Banner
    {
        public int Id { get; set; }
        public bool IsPublished { get; set; }
        public bool IsClosed { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Image Image { get; set; }
        public Category Category { get; set; }
        public IEnumerable<BannerLocalization> BannerLocalizations { get; set; }

    }
}
