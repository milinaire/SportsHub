using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsHubDAL.Entities
{
    
    public class CompanyInfoTranslation
    {
        public Language Language { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
