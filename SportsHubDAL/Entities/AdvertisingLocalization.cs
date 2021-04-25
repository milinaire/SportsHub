using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class AdvertisingLocalization : NoIdDBEntity
    {
        public int AdvertisingId { get; set; }
        public int LanguageId { get; set; }
        public string Headline { get; set; }
        public virtual Language Language { get; set; }
        public virtual Advertising Advertising { get; set; }
    }
}
