using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class NewsLetterSubscription : IDBEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool All { get; set; }
        public virtual Category Category { get; set; }
        public virtual Conference Conference { get; set; }
        public virtual Team Team { get; set; }
        public virtual Language Language { get; set; }
    }
}