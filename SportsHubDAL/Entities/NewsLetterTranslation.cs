using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class NewsLetterTranslation
    {
        public int Id { get; set; }
        public Language Language { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
