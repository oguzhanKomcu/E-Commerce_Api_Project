using AutoMapper;
using ECommerceApi.Application.CQRS.Product.Queries.Request;
using ECommerceApi.Application.CQRS.Product.Queries.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Handlers.Queries
{

    public class GetProductByCategoryHandler : IRequestHandler<GetProductByCategoryRequest, List< GetProductByCategoryResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByCategoryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<GetProductByCategoryResponse>> Handle(GetProductByCategoryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetFilteredList(
                  selector: x => new GetProductByCategoryResponse
                  {
                      Id = x.Id,
                      Name = x.Name,
                      Price = x.Price,
                      ImagePath = x.ImagePath,
                      Category_Name = x.Category.Name,

                  },
                  expression: x => x.Category.Id == request.CategoryId &&
                                x.Status != Domain.Enums.Status.Passive,
                  orderBy: x=> x.OrderBy(x=> x.Name),
                 include: x => x.Include(x => x.Category));


            return products;
        }






        //public async Task<List<GetByIdProductQueryResponse>> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        //{
        //    var product = await _productRepository.GetFilteredFirstOrDefault(
        //        selector: x => new GetAllProductQueryResponse
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            Description = x.Description,
        //            Price = x.Price,
        //        },
        //        expression: x => x.Id == id &&
        //                        x.Status != Domain.Enums.Status.Passive);

        //    var model = _mapper.Map<UpdateProductDTO>(product);

        //    model.Categories = await _unitOfWork.CategoryRepository.GetFilteredList(
        //        selector: x => new GetCategoryVM
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //        },
        //        expression: x => x.Status != Status.Passive,
        //        orderBy: x => x.OrderBy(x => x.Name));

        //    return model;
        //}
    }
}
