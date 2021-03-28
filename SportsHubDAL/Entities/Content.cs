using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public bool IsPublished { get; set; }
        public DateTime Datetime { get; set; }
        public bool ShowComments { get; set; }
        public IEnumerable<Video> Video { get; set; }
        public IEnumerable<Article> Article { get; set; }
        public IEnumerable<Comment> Comment { get; set; }
    }
}