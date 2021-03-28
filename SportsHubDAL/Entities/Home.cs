using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Home
    {
        public int Id { get; set; }
        public bool ShowPhotoOfTheDay { get; set; }
        public Image PhotoOfTheDayImg { get; set; }
        public bool ShowMostPopular { get; set; }
        public bool ShowMostCommented { get; set; }
        public int PeriodId { get; set; }

        public Period Period { get; set; }
        public IEnumerable<PhotoOfTheDayLocalization> PhotoOfTheDayLocalization { get; set; }
    }
}