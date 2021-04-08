using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class AdvertisingLocalization
    {
        public int AdvertisingId { get; set; }
        public int LanguageId { get; set; }
        public string Headline { get; set; }
        public Language Language { get; set; }
        public Advertising Advertising { get; set; }
    }
}
