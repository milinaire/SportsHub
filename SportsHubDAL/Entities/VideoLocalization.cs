using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class VideoLocalization : NoIdDBEntity
    {
        public int VideoId { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public virtual Video Video { get; set; }
        public virtual Language Language { get; set; }
        
    }
}