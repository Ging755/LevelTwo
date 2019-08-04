using AutoMapper;
using LevelTwo.Model.Common;
using LevelTwo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LevelTwo.MVC.App_Start
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ICategory, CategoryVM>().ReverseMap();
            CreateMap<IItem, ItemVM>().ReverseMap();
            CreateMap<IOrder, OrderVM>().ReverseMap();
        }
    }
}