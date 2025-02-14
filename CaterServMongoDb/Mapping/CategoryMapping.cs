﻿using AutoMapper;
using CaterServMongoDb.DataAccess.Entities;
using CaterServMongoDb.Dtos.CategoryDtos;

namespace CaterServMongoDb.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<ResultCategoryDto,Category>().ReverseMap();
            CreateMap<CreateCategoryDto,Category>().ReverseMap();
            CreateMap<UpdateCategoryDto,Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, ResultCategoryDto>().ReverseMap();
        }

    }
}
