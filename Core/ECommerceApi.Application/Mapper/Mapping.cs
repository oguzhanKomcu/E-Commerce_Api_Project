using AutoMapper;
using Core.Persistence.Paging;
using ECommerceApi.Application.CQRS.Product.Commands.Request;
using ECommerceApi.Application.CQRS.Product.Model;
using ECommerceApi.Application.CQRS.Product.Queries.Response;
using ECommerceApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateProductCommandRequest, Product>();
            CreateMap<Product, CreateProductCommandRequest>();
            CreateMap<Product, GetByIdProductQueryResponse>();
            CreateMap<Product, List<GetAllProductQueryResponse>>();
            CreateMap<Product, GetAllProductQueryResponse>();
      
            CreateMap<IPaginate<Product>, ProductListModel>().ReverseMap();
        }
    }
}
