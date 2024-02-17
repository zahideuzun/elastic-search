using AutoMapper;
using ElasticSearch.AppCore.DTOs.BlogDTOs;
using ElasticSearch.AppCore.DTOs.ProductDTOs;
using ElasticSearch.AppCore.Entities.Blog;
using ElasticSearch.AppCore.Entities.Product.Product;

namespace ElasticSearch.AppCore.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile() 
        {
            #region Product
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<ProductFeature, ProductFeatureDto>();
            CreateMap<ProductFeatureDto, ProductFeature>();

            CreateMap<ProductCreateDto, Product>()
            .ForMember(dest => dest.Feature, act => act.MapFrom(src => src.Feature));
            #endregion

            #region Blog

            CreateMap<BlogCreateDto, Blog>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src =>
                    !string.IsNullOrEmpty(src.Tags) ? src.Tags.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray() : Array.Empty<string>()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => Guid.NewGuid())) 
                .ForMember(dest => dest.Created, opt => opt.Ignore());

			#endregion


		}
    }
}
