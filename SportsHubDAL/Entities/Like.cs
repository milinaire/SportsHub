using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Like : IDBEntity
    {
        public int Id { get; set; }
        public bool Dislike { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual ApplicationUser User { get; set; }
      
    }
}