using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Period : IDBEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfDays { get; set; }
        
        public virtual IEnumerable<Home> Home { get; set; }
    }
}