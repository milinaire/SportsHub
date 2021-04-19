using SportsHubDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Interfaces
{
    public interface IDBEntityWithContent: IDBEntity
    {
        public Content Content { get; set; }
}
}
