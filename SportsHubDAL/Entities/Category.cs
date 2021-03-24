using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public bool Show { get; set; }
        public bool IsEditable { get; set; }

        public IEnumerable<Conference> Conferences { get; set; }
    }
}
