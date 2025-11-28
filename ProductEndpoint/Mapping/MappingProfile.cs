using AutoMapper;
using ProductEndpoint.DTOs;
using ProductEndpoint.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductEndpoint.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Product, ProductDto>()
				.ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
				.ForMember(dest => dest.ProductTypeName, opt => opt.MapFrom(src => src.Type.Name))
				.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Pricing != null ? src.Pricing.Price : 0));

			CreateMap<Brand, BrandDto>();
			CreateMap<ProductType, ProductTypeDto>();
			CreateMap<Pricing, PricingDto>();
			CreateMap<Location, LocationDto>();
			CreateMap<MediaItem, MediaItemDto>();
			CreateMap<ProductAttributes, ProductAttributesDto>();
		}
	}
}
