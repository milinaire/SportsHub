using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SportsHubDAL.Interfaces;

namespace SportsHubDAL.Entities
{
    public class Privacy : NoIdDBEntity
    {
        [Key]
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
    }
}
