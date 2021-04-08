using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubDAL.Interfaces
{
    public interface IRepository<T> where T : class, DBEntity
    {
        IQueryable<T> Set();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
