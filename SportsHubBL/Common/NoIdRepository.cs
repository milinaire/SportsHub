using Microsoft.EntityFrameworkCore;
using SportsHubDAL.Data;
using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Common
{
    public class NoIdRepository<T> : INoIdRepository<T> where T : class, NoIdDBEntity
    {
        protected readonly ApplicationDbContext context;
        protected readonly DbSet<T> entities;

        public NoIdRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IQueryable<T> Set()
        {
            return entities;
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
