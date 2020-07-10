using NewsPortalWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortalWebApi.Data_Access_Layer.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<News> News { get; }
        void Save();
    }
}
