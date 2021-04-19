using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using SportsHubDAL.Interfaces;

namespace SportsHubDAL.Entities
{
    public class Comment: IDBEntityWithContent
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        [Column(TypeName = "text")]
        public string Text { get; set; }
        public bool IsEdited { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Content Content { get; set; }
        public virtual IEnumerable<Like> Likes { get; set; }
      
    }
}