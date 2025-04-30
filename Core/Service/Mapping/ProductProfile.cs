using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using DomainLayer.Models.ProductModule;
using Microsoft.Extensions.Options;
using Shared.DataTransfareObjects.ProductModuleDTos;

namespace Service.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTo>()
                .ForMember(dis => dis.BrandName, Options => Options.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dis => dis.TypeName, Options => Options.MapFrom(src => src.ProductType.Name))
                .ForMember(dis => dis.PictureUrl, Options => Options.MapFrom<PictureUrlResolver>());
            CreateMap<ProductBrand, BrandDTo>();

            CreateMap<ProductType, TypeDTo>();
        }
    }
}

