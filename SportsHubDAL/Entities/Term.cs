using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SportsHubDAL.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsHubDAL.Entities
{
    public class Term : NoIdDBEntity
    {
        [Key]
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public string Headline { get; set; }
        [Column(TypeName = "text")]
        public string Text { get; set; }
    }
}
