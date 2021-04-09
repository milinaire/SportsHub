using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Article : DBEntity
    {
        public int Id { get; set; }
        public Image Image { get; set; }
        public Category Category { get; set; }
        public Content Content { get; set; }
        public IEnumerable<MainArticles> MainArticles { get; set; }
        public IEnumerable<ArticleLocalization> ArticleLocalizations { get; set; }
        public IEnumerable<SportArticle> SportArticles { get; set; }
      
    }
}