using AutoMapper;
using ECommerceApi.Application.CQRS.Product.Queries.Request;
using ECommerceApi.Application.CQRS.Product.Queries.Response;
using ECommerceApi.Application.CQRS.Product_Comment.Dtos;
using ECommerceApi.Application.RepositoriesInterface;
using ECommerceApi.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApi.Application.CQRS.Product.Handlers.Queries
{

    public class GetByIdProductQueryHandler : IRequestHandler<GetProductByCategoryQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetProductByCategoryQueryRequest request, CancellationToken cancellationToken)
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
                    Category_Name = x.Category.Name,
                    Rating = x.Product_Ratings.Average(y => y.Rating).ToString(),
                    Total_Comments = x.Product_Comments.Count(y=> y.Id == x.Id).ToString(),

                    Product_Comments = x.Product_Comments.Where(x => x.Product_Id == request.Id && x.Status != Status.Passive)
                    .OrderByDescending(x => x.CreateDate)
                    .Select(x => new ProductCommentDto
                    {
                        Id = x.Id,
                        User_Id = x.User_Id,
                        Text = x.Text,
                        UserImage = x.User.ImagePath,
                        UserName = x.User.UserName,
                        CreateDate = x.CreateDate.ToString()
                    }).ToList(),
                },
                expression: x => x.Id == request.Id &&
                                x.Status != Domain.Enums.Status.Passive) ; 



            return product;
        }






    }
}
