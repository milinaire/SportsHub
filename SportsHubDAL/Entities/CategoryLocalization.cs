using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class CategoryLocalization
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public Category Category { get; set; }
        public Language Language { get; set; }
    }
}
