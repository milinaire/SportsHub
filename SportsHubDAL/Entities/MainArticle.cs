using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class MainArticle : NoIdDBEntity
    {
        [Key]
        public int ArticleId { get; set; }
        public bool Show { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }
    }
}