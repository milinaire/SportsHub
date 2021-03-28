using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class MainArticles
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public bool Show { get; set; }
        
        public Article Article { get; set; }
    }
}