using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class VideoLocalization
    {
        public int VideoId { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public Video Video { get; set; }
        public Language Language{ get; set; }
        
    }
}