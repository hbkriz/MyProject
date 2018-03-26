using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MyProjectBusinessLayer.ViewModels;
using MyProjectDataLayer.Models;

namespace MyProjectApi
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<BasicProfile>();
            });
        }

    }

    public class BasicProfile : Profile
    {
        public BasicProfile()
        {
            CreateMap<Blog, BlogViewModel>().ReverseMap();

            //Custom Mapping
            //CreateMap<ContractCostAllocationViewModel, ContractCostAllocation>()
            //    .ForMember(dest => dest.Cost, opt => opt.MapFrom(src => src.Value))
            //    .ForMember(dest => dest.CodaRefNumber, opt => opt.MapFrom(src => src.RefNumber))
            //    .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.AccountNumber));
        }
    }
}