using AutoMapper;
using Food.API.DTOs.CategoryAttribute;
using Food.API.DTOs.Category;
using Food.API.DTOs.Language;
using Food.API.DTOs.Product;
using Food.API.DTOs.ProductAttribute;
using Food.API.DTOs.ProductImage;
using Food.API.DTOs.Slider;
using Food.API.DTOs.SliderAttribute;
using Food.API.Entities;

namespace Food.API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CategoryReqDto, Category>();
        CreateMap<ProductReqDto, Product>();
        CreateMap<LanguageReqDto, Language>();

        CreateMap<Product, ProductResDto>();
        CreateMap<ProductImage, ProductImageResDto>();
        CreateMap<ProductAttributeReqDto, ProductAttribute>();
        CreateMap<CategoryAttributeReqDto, CategoryAttribute>();
        CreateMap<SliderReqDto, Slider>().ReverseMap();
        CreateMap<Slider, SliderResDto>().ReverseMap();

        CreateMap<SliderAttributeReqDto, SliderAttribute>();
        CreateMap<SliderAttribute, SliderAttributeResDto>();



    }
}