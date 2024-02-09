using AutoMapper;
using ElasticSearch.AppCore.DTOs;
using ElasticSearch.AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.AppCore.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        { 
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<ProductFeature, ProductFeatureDto>();
            CreateMap<ProductFeatureDto, ProductFeature>();

            CreateMap<ProductCreateDto, Product>()
            .ForMember(dest => dest.Feature, act => act.MapFrom(src => src.Feature));
        }
    }
}
