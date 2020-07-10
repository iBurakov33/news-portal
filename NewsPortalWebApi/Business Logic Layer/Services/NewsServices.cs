using NewsPortalWebApi.Business_Logic_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsPortalWebApi.Business_Logic_Layer.DTO;
using NewsPortalWebApi.Data_Access_Layer;
using NewsPortalWebApi.Data_Access_Layer.Models.Interfaces;
using AutoMapper;

namespace NewsPortalWebApi.Business_Logic_Layer.Services
{
    public class NewsServices : INewsService<NewsDTO>
    {
        IUnitOfWork Database { get; set; }
        public NewsServices(IUnitOfWork entity)
        {
            Database = entity;
        }
        public NewsDTO GetNews(Guid Id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<News, NewsDTO>(Database.News.Get(Id));
        }

        public IEnumerable<NewsDTO> GetAllNews()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsDTO>>(Database.News.GetAll());
        }
    }
}
