using Microsoft.EntityFrameworkCore;
using NewsPortalWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortalWebApi.Data_Access_Layer.Models
{
    public class NewsRepository : IRepository<News>
    {
        private NewsPortalWebApiContext db;

        public NewsRepository(NewsPortalWebApiContext context)
        {
            this.db = context;
        }
        public void Add(News entity)
        {
            db.Add(entity);
        }

        public void Delete(Guid id)
        {
            News entity = db.News.Find(id);
            if (entity != null)
                db.News.Remove(entity);
        }

        public News Get(Guid id)
        {
            return db.News.Find(id);
        }

        public IEnumerable<News> GetAll()
        {
            return db.News;
        }

        public void Update(News entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
