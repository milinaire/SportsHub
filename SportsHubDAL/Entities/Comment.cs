using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Datetime { get; set; }
        public string Text { get; set; }
        public bool IsEdited { get; set; }
        public int ContentId { get; set; }

        public User User{ get; set; }
        public Content Content { get; set; }
        public IEnumerable<Like> Like { get; set; }
      
    }
}