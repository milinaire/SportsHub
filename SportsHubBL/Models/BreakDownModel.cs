using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Models
{
    class BreakDownModel
    {
        public int Id { get; set; }
        public bool Show { get; set; }
        public int Languageid { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ConferenceId { get; set; }
        public string ConferenceName { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }

    }
}
