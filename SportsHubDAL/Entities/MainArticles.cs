using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Entities
{
    public class MainArticles : IDBEntity
    {
        public int Id { get; set; }
        public bool Show { get; set; }
        public Article Article { get; set; }
    }
}