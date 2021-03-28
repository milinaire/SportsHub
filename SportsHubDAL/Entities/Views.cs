using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Views
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        public Content Content { get; set; }
        public User User{ get; set; }
      
    }
}