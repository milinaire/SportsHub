using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class NewsLetterSubscription
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public int TeamId { get; set; }
        public int LanguageId { get; set; }
        public bool All { get; set; }

        public Category Category{ get; set; }
        public Subcategory Subcategory{ get; set; }
        public Team Team{ get; set; }
        public Language Language{ get; set; }
     
    }
}