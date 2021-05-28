using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Banner : IDBEntity
    {
        public int Id { get; set; }
        public bool IsPublished { get; set; }
        public bool IsClosed { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public virtual Image Image { get; set; }
        public virtual Category Category { get; set; }
        public virtual IEnumerable<BannerLocalization> BannerLocalizations { get; set; }

    }
}
