using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace SportsHubDAL.Entities
{
    public class SportArticle: NoIdDBEntity
    {
        [Key]
        public int ArticleId { get; set; }
        public int TeamId { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }
        public virtual Team Team { get; set; }
    }
}