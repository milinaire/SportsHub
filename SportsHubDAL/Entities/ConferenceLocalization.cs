using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SportsHubDAL.Entities
{
    public class ConferenceLocalization : NoIdDBEntity
    {
        public string Name { get; set; }
        public int ConferenceId { get; set; }
        public int LanguageId { get; set; }
        [JsonIgnore]
        public virtual Conference Conference { get; set; }
        [JsonIgnore]
        public virtual Language Language { get; set; }
    }
}
