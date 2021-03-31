using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public Image Image { get; set; }
        public Category Category { get; set; }
        public Content Content { get; set; }
        public IEnumerable<MainArticles> MainArticles { get; set; }
        public IEnumerable<ArticleLocalization> ArticleTranslation { get; set; }
        public IEnumerable<SportArticle> SportArticle { get; set; }
      
    }
}