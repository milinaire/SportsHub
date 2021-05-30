using SportsHubDAL.Data;
using SportsHubDAL.Entities;
using SportsHubDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsHubBL.Common
{
    public class ArticleRepository : Repository<Article>, IRepository<IDBEntityWithContent>
    {
        public ArticleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public new IQueryable<IDBEntityWithContent> Set()
        {
            return entities;
        }

        public void Insert(IDBEntityWithContent entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add((Article)entity);
            context.SaveChanges();
        }
        public void Update(IDBEntityWithContent entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.SaveChanges();
        }

        public void Delete(IDBEntityWithContent entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entities.Remove((Article)entity);
            context.SaveChanges();
        }

        public new IDBEntityWithContent GetById(int id)
        {
            return entities.FirstOrDefault(e => e.Id == id);
        }
    }
}
