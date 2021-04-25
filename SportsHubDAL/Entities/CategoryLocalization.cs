using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class CategoryLocalization : NoIdDBEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Language Language { get; set; }
    }
}
