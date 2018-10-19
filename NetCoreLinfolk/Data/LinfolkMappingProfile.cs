using AutoMapper;
using NetCoreLinfolk.Data.Entities;
using NetCoreLinfolk.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Data
{
    public class LinfolkMappingProfile : Profile
    {
        public LinfolkMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>().ForMember(o => o.Id, ex => ex.MapFrom(o => o.Id)).ReverseMap();
            CreateMap<SubCategory, SubCategoryViewModel>().ReverseMap();
        } 
    }
}
