using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class ConferenceLocalization : NoIdDBEntity
    {
        public string Name { get; set; }
        public int ConferenceId { get; set; }
        public int LanguageId { get; set; }
        public virtual Conference Conference { get; set; }
        public virtual Language Language { get; set; }
    }
}
