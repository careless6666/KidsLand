using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using KidsLand.Models.EF;
using KidsLand.Models.ViewModels;

namespace KidsLand.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<NewsViewModel, News>();
            Mapper.CreateMap<News, NewsViewModel>();
        }
        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}