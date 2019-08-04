using AutoMapper;
using LevelTwo.DAL.Entities;
using LevelTwo.Model;
using LevelTwo.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTwo.Repository
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryEntity, ICategory>().ReverseMap();
            CreateMap<ItemEntity, IItem>().ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.CategoryEntityId))
                .ReverseMap().ForMember(dest => dest.CategoryEntityId, opts => opts.MapFrom(src => src.CategoryId));
            CreateMap<OrderEntity, IOrder>().ReverseMap();
        }
    }
}
