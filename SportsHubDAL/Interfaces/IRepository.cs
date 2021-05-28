using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Interfaces
{
    public interface IRepository<T>:INoIdRepository<T> where T : class, IDBEntity
    {
        T GetById(int id);
    }
}
