using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Image: NoIdDBEntity
    {
        public int Id { get; set; }

        [Required]
        public string Uri { get; set; }
    }
}
