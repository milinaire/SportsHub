using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Models
{
    public class ConferenceModel
    {
        public int ConferenceId { get; set; }
        public int CategoryId { get; set; }
        public bool Show { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
    }
}
