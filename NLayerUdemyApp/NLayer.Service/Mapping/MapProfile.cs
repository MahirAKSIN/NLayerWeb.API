using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductEntity, ProductDTO>().ReverseMap();
            CreateMap<CategoryEntity, CategoryDTO>().ReverseMap();
            CreateMap<ProductFeatureEntity, ProductFeaturesDto>().ReverseMap();
            CreateMap<ProductUpdateDto, ProductEntity>();
            CreateMap<ProductEntity, ProductWithCategoryDto>();
            CreateMap<CategoryEntity, CategoryWithProductDto>();
        }

    }
}
