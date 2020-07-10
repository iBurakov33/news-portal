using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsPortalWebApi.Data;
using NewsPortalWebApi.Data_Access_Layer.Models;
using NewsPortalWebApi.Data_Access_Layer.Models.Interfaces;

namespace NewsPortalWebApi.Data_Access_Layer.EFCore
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private NewsPortalWebApiContext db;
        private NewsRepository newsRepository;

        public EFUnitOfWork(NewsPortalWebApiContext context)
        {
            this.db = context;
        }

        IRepository<News> IUnitOfWork.News
        {
            get
            {
                if (newsRepository == null)
                { 
                    newsRepository = new NewsRepository(db);
                }
                return newsRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
