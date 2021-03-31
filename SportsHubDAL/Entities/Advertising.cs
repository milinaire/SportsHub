using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Advertising
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public Image Image { get; set; }
        public DateTime DateOfCreation { get; set; }
        public IEnumerable<AdvertisingLocalization> AdvertisingLocalization { get; set; }
        public IEnumerable<CategoryAd> CategoryAd { get; set; }
    }
}
