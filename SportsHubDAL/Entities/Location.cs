using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsHubDAL.Entities
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string Uri { get; set; }
    }
}
