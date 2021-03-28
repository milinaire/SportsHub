using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Role { get; set; }

        public IEnumerable<User> User { get; set; }
    }
}