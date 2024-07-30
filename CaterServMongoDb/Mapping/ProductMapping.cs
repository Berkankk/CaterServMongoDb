using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.ProductDtos;

namespace CaterServMongoDb.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<ResultProductDto, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategories>().ReverseMap();
        }
    }
}
