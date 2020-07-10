using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using NewsPortalWebApi.Business_Logic_Layer;
using NewsPortalWebApi.Data;
using NewsPortalWebApi.Business_Logic_Layer.DTO;
using NewsPortalWebApi.Business_Logic_Layer.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NewsPortalWebApi.Presentation_Layer.Controllers
{
    public class NewsController : ControllerBase
    {
        INewsService<NewsDTO> newsService;
        public NewsController(INewsService<NewsDTO> service)
        {
            newsService = service;
        }

        public IEnumerable<NewsDTO> GetAllNews()
        {
            return newsService.GetAllNews();
        }

        public NewsDTO GetNews(Guid Id)
        {
            return newsService.GetNews(Id);
        }
    }
}
