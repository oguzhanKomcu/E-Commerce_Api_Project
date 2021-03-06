using AutoMapper;
using ECommerceApi.Application.CQRS.Product.Queries.Request;
using ECommerceApi.Application.CQRS.Product.Queries.Response;
using ECommerceApi.Application.RepositoriesInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Handlers.Queries
{

    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetFilteredFirstOrDefault(
                selector: x => new GetByIdProductQueryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Size = x.Size,
                    Color = x.Color,
                    ImagePath = x.ImagePath,
                    Stock = x.Stock,
                    Category_Name = x.Category.Name
                },
                expression: x => x.Id == request.Id &&
                                x.Status != Domain.Enums.Status.Passive);

            //var model = _mapper.Map<UpdateProductDTO>(product);

            //model.Categories = await _unitOfWork.CategoryRepository.GetFilteredList(
            //    selector: x => new GetCategoryVM
            //    {
            //        Id = x.Id,
            //        Name = x.Name,
            //    },
            //    expression: x => x.Status != Status.Passive,
            //    orderBy: x => x.OrderBy(x => x.Name));

            return product;
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
