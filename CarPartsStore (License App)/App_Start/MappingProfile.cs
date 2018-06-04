using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CarPartsStore__License_App_.Dto;
using CarPartsStore__License_App_.Models;

namespace CarPartsStore__License_App_.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarType, CarTypeDTO>();
            CreateMap<CarTypeDTO, CarType>();
            CreateMap<Category, CategoriesDTO>();
            CreateMap<CategoriesDTO, Category>();
            CreateMap<Supplier, SuppliersDTO>();
            CreateMap<SuppliersDTO, Supplier>();
            CreateMap<Manufacture, ManufactureDTO>();
            CreateMap<ManufactureDTO, Manufacture>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Body, BodyDTO>();
            CreateMap<BodyDTO, Body>();
            CreateMap<Attributes, AttributeDTO>();
            CreateMap<AttributeDTO, Attributes>();
            CreateMap<AttributeValue, AttributeValueDTO>();
            CreateMap<AttributeValueDTO, AttributeValue>();
            CreateMap<ProductAttributeValue, ProductAttributeDTO>();
            CreateMap<ProductAttributeDTO, ProductAttributeValue>();
        }
    }
}