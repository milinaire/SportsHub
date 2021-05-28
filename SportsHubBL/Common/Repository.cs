using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsHubDAL.Data;
using SportsHubDAL.Interfaces;

namespace SportsHubBL.Common
{
    public class Repository<T>:NoIdRepository<T>, IRepository<T> where T: class, IDBEntity
    {
        public Repository(ApplicationDbContext context):base(context)
        {

        }

        public T GetById(int id)
        {
            return entities.FirstOrDefault(e => e.Id == id);
        }
    }
}