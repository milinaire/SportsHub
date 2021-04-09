using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Views: IDBEntityWithContent
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Content Content { get; set; }
        public ApplicationUser User{ get; set; }
      
    }
}