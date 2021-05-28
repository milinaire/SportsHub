using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SportsHubDAL.Interfaces;

namespace SportsHubDAL.Entities
{
    public class ContributorsLocalization : NoIdDBEntity
    {
        [Key]
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public string Title { get; set; }
    }
}
