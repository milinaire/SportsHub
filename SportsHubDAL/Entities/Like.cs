using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public bool Dislike { get; set; }
        public Comment Comment { get; set; }
        public ApplicationUser User { get; set; }
      
    }
}