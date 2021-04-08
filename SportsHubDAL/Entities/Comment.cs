using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsHubDAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Datetime { get; set; }
        [Column(TypeName = "text")]
        public string Text { get; set; }
        public bool IsEdited { get; set; }
        public ApplicationUser User { get; set; }
        public Content Content { get; set; }
        public IEnumerable<Like> Likes { get; set; }
      
    }
}