using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class PhotoOfTheDayLocalization
    {
        public int PhotoOfTheDayId { get; set; }
        public Home Home { get; set; }
        public string PhotoOfTheDayAlt { get; set; }
        public string PhotoOfTheDayTitle { get; set; }
        public string PhotoOfTheDayDesciption { get; set; }
        public string PhotoOfTheDayAuthor { get; set; }
        public int LanguageId { get; set; }

        public Language Language { get; set; }
     
    }
}