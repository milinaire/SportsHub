using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Content Content { get; set; }
        public IEnumerable<VideoLocalization> VideoTrasnlations { get; set; }
    }
}