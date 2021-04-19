using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Article : IDBEntityWithContent
    {
        public int Id { get; set; }
        public virtual Image Image { get; set; }
        public virtual Category Category { get; set; }
        public virtual Content Content { get; set; }
        public virtual IEnumerable<MainArticle> MainArticles { get; set; }
        public virtual IEnumerable<ArticleLocalization> ArticleLocalizations { get; set; }
        public virtual IEnumerable<SportArticle> SportArticles { get; set; }
      
    }
}