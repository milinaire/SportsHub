using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Video: IDBEntityWithContent
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public virtual Content Content { get; set; }
        public virtual IEnumerable<VideoLocalization> VideoLocalizations { get; set; }
    }
}