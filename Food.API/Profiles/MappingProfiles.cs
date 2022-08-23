﻿using AutoMapper;
using Food.API.DTOs.CategoryAttribute;
using Food.API.DTOs.Category;
using Food.API.DTOs.Language;
using Food.API.DTOs.Product;
using Food.API.DTOs.ProductAttribute;
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


        CreateMap<ProductAttributeReqDto, ProductAttribute>();
        CreateMap<CategoryAttributeReqDto, CategoryAttribute>();
        CreateMap<SliderReqDto, Slider>();
        CreateMap<SliderAttributeReqDto, SliderAttribute>();


    }
}