using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Models
{
    public class TeamModel
    {
        public int TeamId { get; set; }
        
        public int? ConferenceId { get; set; }
        
        public int? LanguageId { get; set; }
        
        public int? CategoryId { get; set; }

        public int? LocationId { get; set; }
        
        public string LocationUri { get; set; }

        public bool? Show { get; set; }
        
        public int? ImageId { get; set; }

        public string ImageUri { get; set; }
        
        public DateTime? DateCreated { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
    }
}