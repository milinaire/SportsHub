using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using SportsHubDAL.Interfaces;
using System.Text.Json.Serialization;

namespace SportsHubDAL.Entities
{
    public class ArticleLocalization: NoIdDBEntity
    {
        public int ArticleId { get; set; }
        public int LanguageId { get; set; }
        [JsonIgnore]
        public virtual Article Article { get; set; }
        [JsonIgnore]
        public virtual Language Language { get; set; }
        public string Headline { get; set; }
        [Column(TypeName = "text")]
        public string Text { get; set; }
        public string Caption { get; set; }
        public string Alt { get; set; }

    }
}
