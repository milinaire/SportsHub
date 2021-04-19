using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Home : IDBEntity
    {
        public int Id { get; set; }
        public bool ShowPhotoOfTheDay { get; set; }
        public virtual Image PhotoOfTheDayImg { get; set; }
        public bool ShowMostPopular { get; set; }
        public bool ShowMostCommented { get; set; }
        public virtual Period Period { get; set; }
        public virtual IEnumerable<PhotoOfTheDayLocalization> PhotoOfTheDayLocalization { get; set; }
    }
}