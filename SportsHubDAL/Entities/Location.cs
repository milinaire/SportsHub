using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SportsHubDAL.Interfaces;

namespace SportsHubDAL.Entities
{
    public class Location: NoIdDBEntity
    {
        public int Id { get; set; }

        [Required]
        public string Uri { get; set; }
        public IEnumerable<SportArticle> SportArticle { get; set; }
    }
}
