using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsHubDAL.Entities
{
    public class Privacy
    {
        [Key]
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public string Headline { get; set; }

        public string Text { get; set; }
    }
}
