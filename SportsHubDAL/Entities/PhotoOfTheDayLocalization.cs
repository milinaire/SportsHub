using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class PhotoOfTheDayLocalization : NoIdDBEntity
    {
        public int PhotoOfTheDayId { get; set; }
        public virtual Home Home { get; set; }
        public string PhotoOfTheDayAlt { get; set; }
        public string PhotoOfTheDayTitle { get; set; }
        public string PhotoOfTheDayDesciption { get; set; }
        public string PhotoOfTheDayAuthor { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
     
    }
}