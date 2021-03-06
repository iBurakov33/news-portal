﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using NewsPortalWebApi.Data_Access.Interfaces;
using NewsPortalWebApi.Data_Access.Models;
using NewsPortalWebApi.Business_Logic.Inerfaces;
using NewsPortalWebApi.Business_Logic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortalWebApi.Business_Logic.Services
{
    /// <summary>
    /// Класс служб для работы с новостями
    /// </summary>
    public class NewsServices : INewsService<NewsShortDto, NewsDetailDto, AuthorDTO>
    {
        /// <summary>
        /// Создание служб по классу работы с репозиториями
        /// </summary>
        private readonly IUnitOfWork _db;
        /// <summary>
        /// Создание служб по классу работы с репозиториями
        /// </summary>
        /// <param name="entity"></param>
        public NewsServices(IUnitOfWork entity)
        {
            _db = entity;
        }

        /// <summary>
        /// Метод получения новости по Id
        /// </summary>
        /// <param name="id">
        /// Id новости
        /// </param>
        /// <remarks>
        /// Происходит проецирование модели News на NewsDetailDTO
        /// </remarks>
        /// <returns>
        /// Возвращает новость по ее id
        /// </returns>
        NewsDetailDto INewsService<NewsShortDto, NewsDetailDto, AuthorDTO>.GetNews(Guid id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsDetailDto>()).CreateMapper();
            return mapper.Map<News, NewsDetailDto>(_db.GetNewsRep.Get(id));
        }
        /// <summary>
        /// Метод получения всех новостей
        /// </summary>
        /// <remarks>
        /// проецирование модели News на NewsShortDTO
        /// </remarks>
        /// <returns>
        /// Возвращает все новости в коротком формате
        /// </returns>
        IEnumerable<NewsShortDto> INewsService<NewsShortDto, NewsDetailDto, AuthorDTO>.GetAllNews()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsShortDto>()).CreateMapper();
            return mapper.Map<IEnumerable<News>, List<NewsShortDto>>(_db.GetNewsRep.GetAll());
        }
        
        AuthorDTO INewsService<NewsShortDto, NewsDetailDto, AuthorDTO>.GetAuthorName(Guid id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Author, AuthorDTO>()).CreateMapper();
            return mapper.Map<Author, AuthorDTO>(_db.GetAuthorsRep.Get(id));
        }
    }
}
